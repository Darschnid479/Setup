Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions

Public Class MemberProfile
    Public Property FirstName As String = ""
    Public Property LastName As String = ""
    Public Property Role As String = "Deltaker"
    Public Property Experience As String = "Helt ny"
    Public ReadOnly Property FullName As String
        Get
            Return (FirstName & " " & LastName).Trim()
        End Get
    End Property
    Public ReadOnly Property Username As String
        Get
            Return Names.ToUsername(FirstName)
        End Get
    End Property
    Public ReadOnly Property WorkEmail As String
        Get
            Return If(Username.Length = 0, "", Username & "@ki-laben.no")
        End Get
    End Property
End Class

Public Module Names
    Public Function ToUsername(firstName As String) As String
        ' Only the first given-name token; never the surname.
        Dim token = Regex.Split(If(firstName, "").Trim().ToLowerInvariant(), "\s+")(0)
        token = token.Replace("æ", "ae").Replace("ø", "o").Replace("å", "a")
        Dim b As New StringBuilder()
        For Each c As Char In token.Normalize(NormalizationForm.FormD)
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then b.Append(c)
        Next
        Return Regex.Replace(b.ToString(), "[^a-z0-9-]", "")
    End Function
End Module

Public Class SetupState
    Public Property Profile As New MemberProfile()
    Public Property CurrentStep As Integer
    Public Property SelectedBrowser As String = "chrome"
    Public Property Completed As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
    Public Property Remember As Boolean = False
    Public Property Animations As Boolean = True
End Class

Public Class SetupSettings
    Public Property AiEndpoint As String = ""
    Public Property DiscordInvite As String = ""
    Public Property DefaultBrowser As String = "chrome"
End Class

Public Module Steps
    Public ReadOnly Keys As String() = {"profile", "browser", "email", "google", "chatgpt", "discord", "drive"}
    Public ReadOnly Titles As String() = {"Din profil", "Velg nettleser", "Arbeids-e-post", "Google / Workspace", "ChatGPT", "Discord", "Drive", "AI-hjelp", "Oppsummering"}
    Public ReadOnly Guides As String() = {
        "Fyll inn navnet ditt. Vi foreslår fornavn@ki-laben.no. Veileder avklarer stavemåte og eventuelle navnekollisjoner. Ingen privat e-post brukes.",
        "Velg Chrome, Firefox eller Edge. Last ned og start installasjonen når filen er kontrollert. Vi endrer ikke Windows-standardnettleseren uten at du velger det selv.",
        "Kontoen må være opprettet av KI-Laben. Åpne Domeneshop webmail, logg inn og kontroller at du kan motta en testmelding. Programmet oppretter ikke e-postboksen.",
        "Bruk invitasjon til KI-Labens Workspace-team når dere har en. Ellers avklar med veileder før du lager en egen Google-konto med eksisterende arbeidsadresse. Ikke opprett en ny Gmail-adresse.",
        "1. Åpne Domeneshop webmail." & vbCrLf & "2. Finn invitasjonen fra ChatGPT/OpenAI; se også søppelpost." & vbCrLf & "3. Godta lenken med samme @ki-laben.no-adresse invitasjonen gjelder." & vbCrLf & "4. Bytt til KI-Labens arbeidsområde ved behov." & vbCrLf & "5. Start en testsamtale. Mangler invitasjonen: be veileder sende på nytt, ikke kjøp et privat abonnement.",
        "Last ned Discord fra den offisielle kilden. Start installasjonsfilen etter signaturkontroll. Opprett eller bruk kontoen veileder har godkjent. Godta den faktiske serverinvitasjonen og send en testmelding.",
        "Åpne Drive med KI-Laben-kontoen. Finn mappene veileder har delt, opprett et testdokument, og kontroller at det lagres.",
        "Spør om steget du står fast på. AI gir veiledning, men lager ikke kontoer og kjører ikke kommandoer. Navn og arbeidsadresse legges ikke automatisk ved spørsmålet.",
        "Se hva som er bekreftet. Nedlastet fil er ikke det samme som ferdig installert app eller godkjent konto. Rapporten kan lagres eller kopieres til veileder."
    }
End Module
