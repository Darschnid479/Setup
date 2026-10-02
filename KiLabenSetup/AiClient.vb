Imports System
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.Json
Imports System.Threading
Imports System.Threading.Tasks

Friend NotInheritable Class AiClient
    Public Async Function AskAsync(endpoint As String, sessionCode As String, question As String, stepKey As String, cancellation As CancellationToken) As Task(Of String)
        If String.IsNullOrWhiteSpace(endpoint) Then Throw New InvalidOperationException("AI er ikke koblet til ennå. Veileder må konfigurere AI-serveren. Den lokale stegveiledningen virker uten AI.")
        If Not UrlPolicy.IsAiEndpoint(endpoint) Then Throw New InvalidOperationException("AI-serveren må bruke HTTPS. Lokal utvikling kan bruke loopback.")
        If String.IsNullOrWhiteSpace(sessionCode) OrElse sessionCode.Length < 32 Then Throw New InvalidOperationException("Skriv inn den midlertidige AI-tilgangskoden fra veileder, ikke en OpenAI API-nøkkel.")
        If sessionCode.StartsWith("sk-", StringComparison.OrdinalIgnoreCase) Then Throw New InvalidOperationException("OpenAI API-nøkler skal bare ligge på serveren. Bruk KI-Labens midlertidige tilgangskode.")
        If question.Trim().Length = 0 OrElse question.Length > 1600 Then Throw New InvalidOperationException("Skriv et spørsmål på opptil 1600 tegn.")
        Using handler As New HttpClientHandler With {.AllowAutoRedirect = False}
            Using client As New HttpClient(handler) With {.Timeout = TimeSpan.FromSeconds(60), .MaxResponseContentBufferSize = 65536}
                Dim payload = JsonSerializer.Serialize(New With {.question = question.Trim(), .[step] = stepKey})
                Using request As New HttpRequestMessage(HttpMethod.Post, endpoint)
                    request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", sessionCode.Trim())
                    request.Content = New StringContent(payload, Encoding.UTF8, "application/json")
                    Using response = Await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellation)
                        If Not response.IsSuccessStatusCode Then
                            Select Case CInt(response.StatusCode)
                                Case 401, 403 : Throw New InvalidOperationException("AI-tilgangskoden er ugyldig eller utløpt. Be veileder om ny kode.")
                                Case 429 : Throw New InvalidOperationException("AI har nådd forespørselsgrensen. Vent litt eller kontakt veileder.")
                                Case Else : Throw New InvalidOperationException("AI-serveren svarte ikke som forventet. Den lokale veiledningen er fortsatt tilgjengelig.")
                            End Select
                        End If
                        Dim json = Await response.Content.ReadAsStringAsync(cancellation)
                        Using doc = JsonDocument.Parse(json)
                            Dim answer As JsonElement
                            If Not doc.RootElement.TryGetProperty("answer", answer) Then Throw New InvalidOperationException("AI-serveren returnerte ikke noe svar.")
                            Return If(answer.GetString(), "Ingen svartekst mottatt.")
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class
