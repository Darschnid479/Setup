# Endre utseendet i Visual Studio

Åpne `.sln`, bygg og høyreklikk MainForm.vb > View Designer (Shift+F7).
Velg riktig fane i TabControl. Faner er skjult under kjøring, ikke i Designer.
F4 åpner Properties. Tekster, posisjoner, størrelser og felt kan endres der.

Alle vanlige kontroller opprettes direkte i `InitializeComponent` i
MainForm.Designer.vb. Ingen egne BuildProfileTab-metoder skjuler skjermbildene.
Bildet lastes fra embedded resource ved kjøring; Designer viser PictureBox-feltet.
Ingen .resx er brukt. Hvis Designer senere lager en .resx ved redigering, må den
behandles som vanlig prosjektfil og ikke som grunn til å skru av sikkerheten.

Uttrykket: marineblå base, turkis hovedhandling, lys typografi, svake lilla detaljer.
Sidebar er alltid synlig. Scrollbare sider beskytter kontroller på mindre skjermer.
Ved smal visning kan horisontal rulling være nødvendig; kontroller laptop/DPI på
deres Windows-maskiner før utrulling.

`UiMotion.vb` styrer hover/fokusfarger, glidende aktivmarkør, fremdriftsfyll og
orbitalgrafikk i headeren. Den offisielle logoen flyttes, roteres eller tones ikke ut.
Animasjon styres av bryteren på profilsiden og Windows' bevegelsesinnstilling ved start.
Timer og GDI-ressurser disponeres ved avslutning. Ingen tredjeparts UI-pakke trengs.

`BYGG.bat` er startpunkt. `scripts/Build.ps1` viser faktiske byggesteg, en spinner og
tidtaking. Prosent/ferdige steg er ikke en oppdiktet installeringsprosent.
Bruk `BYGG.bat -NoAnimation` for et stille, statisk byggedashboard.
