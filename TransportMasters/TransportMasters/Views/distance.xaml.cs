using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using TransportMasters.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace TransportMasters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class distance : ContentPage
    {
        public distance()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public int ActualId { get; set; } = 410;
        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {

                Destination destination = new Destination();
                List<ImportCityData> _object = ReturnCityObject(ActualId);

                var address = "Rynek"+" " + _object[0].Name + " " + ReturnState(_object[0].StateId) + " " + ReturnCountry(1);
                //var address = "Microsoft Building 25 Redmond WA USA";
                var locations = await Geocoding.GetLocationsAsync(address);
                var location = locations?.FirstOrDefault();
                
                if (address != null)
                {

                    fullAdress.Text = address.ToString();
                    id.Text = ActualId.ToString();
                    name.Text = _object[0].Name;
                    lat.Text = location.Latitude.ToString();
                    lon.Text = location.Latitude.ToString();
                   
                    PostToApi(_object[0].Name, location.Longitude, location.Latitude, _object[0].StateId);
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild 3", ex.Message, "OK");
                ActualId++;
            }

        }
        private async void PostToApi(string name, double lon, double lat, int state)
        {
            HttpClient client = new HttpClient();

            Destination _object = new Destination();

            _object.Name = name;
            _object.Lon = lon;
            _object.Lat = lat;
            _object.State = state;
            _object.Country = 1;
            _object.Continent = 1;

            StringContent content = new StringContent(JsonConvert.SerializeObject(_object), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://transportmastersapi.azurewebsites.net/api/importData", content);
            if (response.IsSuccessStatusCode)
            {
                ActualId++;
            }
        }

        private string ReturnState(int stateId)
        {
            var _state = "NULL";

            if (stateId == 2) { _state = "DOLNOŚLĄSKIE"; };
            if (stateId == 4) { _state = "KUJAWSKO-POMORSKIE"; };
            if (stateId == 6) { _state = "LUBELSKIE"; };
            if (stateId == 8) { _state = "LUBUSKIE"; };
            if (stateId == 10) { _state = "ŁÓDZKIE"; };
            if (stateId == 12) { _state = "MAŁOPOLSKIE"; };
            if (stateId == 14) { _state = "MAZOWIECKIE"; };
            if (stateId == 16) { _state = "OPOLSKIE"; };
            if (stateId == 18) { _state = "PODKARPACKIE"; };
            if (stateId == 20) { _state = "PODLASKIE"; };
            if (stateId == 22) { _state = "POMORSKIE"; };
            if (stateId == 24) { _state = "ŚLĄSKIE"; };
            if (stateId == 26) { _state = "ŚWIĘTOKRZYSKIE"; };
            if (stateId == 28) { _state = "WARMIŃSKO-MAZURSKIE"; };
            if (stateId == 30) { _state = "WIELKOPOLSKIE"; };
            if (stateId == 32) { _state = "ZACHODNIOPOMORSKIE"; };


            return _state;
        }
        private string ReturnCountry(int countryId)
        {
            var _country = "NULL";
            if (countryId == 1) { _country = "Polska"; };
            return _country;
        }
        private string ReturnContinent(int continentId)
        {
            var _continent = "NULL";
            if (continentId == 1) { _continent = "Europa"; };
            return _continent;
        }
        private List<ImportCityData> ReturnCityObject(int citytId)
        {
            List<ImportCityData> _list = new List<ImportCityData>();
            ImportCityData item = new ImportCityData();

            if (citytId == 1) { item.StateId = 2; item.Name = "Bolesławiec"; _list.Add(item); };
            if (citytId == 2) { item.StateId = 2; item.Name = "Nowogrodziec"; _list.Add(item); };
            if (citytId == 3) { item.StateId = 2; item.Name = "Bielawa"; _list.Add(item); };
            if (citytId == 4) { item.StateId = 2; item.Name = "Dzierżoniów"; _list.Add(item); };
            if (citytId == 5) { item.StateId = 2; item.Name = "Pieszyce"; _list.Add(item); };
            if (citytId == 6) { item.StateId = 2; item.Name = "Piława Górna"; _list.Add(item); };
            if (citytId == 7) { item.StateId = 2; item.Name = "Niemcza"; _list.Add(item); };
            if (citytId == 8) { item.StateId = 2; item.Name = "Głogów"; _list.Add(item); };
            if (citytId == 9) { item.StateId = 2; item.Name = "Góra"; _list.Add(item); };
            if (citytId == 10) { item.StateId = 2; item.Name = "Wąsosz"; _list.Add(item); };
            if (citytId == 11) { item.StateId = 2; item.Name = "Jawor"; _list.Add(item); };
            if (citytId == 12) { item.StateId = 2; item.Name = "Bolków"; _list.Add(item); };
            if (citytId == 13) { item.StateId = 2; item.Name = "Karpacz"; _list.Add(item); };
            if (citytId == 14) { item.StateId = 2; item.Name = "Kowary"; _list.Add(item); };
            if (citytId == 15) { item.StateId = 2; item.Name = "Piechowice"; _list.Add(item); };
            if (citytId == 16) { item.StateId = 2; item.Name = "Szklarska Poręba"; _list.Add(item); };
            if (citytId == 17) { item.StateId = 2; item.Name = "Kamienna Góra"; _list.Add(item); };
            if (citytId == 18) { item.StateId = 2; item.Name = "Lubawka"; _list.Add(item); };
            if (citytId == 19) { item.StateId = 2; item.Name = "Duszniki-Zdrój"; _list.Add(item); };
            if (citytId == 20) { item.StateId = 2; item.Name = "Kłodzko"; _list.Add(item); };
            if (citytId == 21) { item.StateId = 2; item.Name = "Kudowa-Zdrój"; _list.Add(item); };
            if (citytId == 22) { item.StateId = 2; item.Name = "Nowa Ruda"; _list.Add(item); };
            if (citytId == 23) { item.StateId = 2; item.Name = "Polanica-Zdrój"; _list.Add(item); };
            if (citytId == 24) { item.StateId = 2; item.Name = "Bystrzyca Kłodzka"; _list.Add(item); };
            if (citytId == 25) { item.StateId = 2; item.Name = "Lądek-Zdrój"; _list.Add(item); };
            if (citytId == 26) { item.StateId = 2; item.Name = "Międzylesie"; _list.Add(item); };
            if (citytId == 27) { item.StateId = 2; item.Name = "Radków"; _list.Add(item); };
            if (citytId == 28) { item.StateId = 2; item.Name = "Stronie Śląskie"; _list.Add(item); };
            if (citytId == 29) { item.StateId = 2; item.Name = "Szczytna"; _list.Add(item); };
            if (citytId == 30) { item.StateId = 2; item.Name = "Chojnów"; _list.Add(item); };
            if (citytId == 31) { item.StateId = 2; item.Name = "Prochowice"; _list.Add(item); };
            if (citytId == 32) { item.StateId = 2; item.Name = "Lubań"; _list.Add(item); };
            if (citytId == 33) { item.StateId = 2; item.Name = "Świeradów-Zdrój"; _list.Add(item); };
            if (citytId == 34) { item.StateId = 2; item.Name = "Leśna"; _list.Add(item); };
            if (citytId == 35) { item.StateId = 2; item.Name = "Olszyna"; _list.Add(item); };
            if (citytId == 36) { item.StateId = 2; item.Name = "Lubin"; _list.Add(item); };
            if (citytId == 37) { item.StateId = 2; item.Name = "Ścinawa"; _list.Add(item); };
            if (citytId == 38) { item.StateId = 2; item.Name = "Gryfów Śląski"; _list.Add(item); };
            if (citytId == 39) { item.StateId = 2; item.Name = "Lubomierz"; _list.Add(item); };
            if (citytId == 40) { item.StateId = 2; item.Name = "Lwówek Śląski"; _list.Add(item); };
            if (citytId == 41) { item.StateId = 2; item.Name = "Mirsk"; _list.Add(item); };
            if (citytId == 42) { item.StateId = 2; item.Name = "Wleń"; _list.Add(item); };
            if (citytId == 43) { item.StateId = 2; item.Name = "Milicz"; _list.Add(item); };
            if (citytId == 44) { item.StateId = 2; item.Name = "Oleśnica"; _list.Add(item); };
            if (citytId == 45) { item.StateId = 2; item.Name = "Bierutów"; _list.Add(item); };
            if (citytId == 46) { item.StateId = 2; item.Name = "Międzybórz"; _list.Add(item); };
            if (citytId == 47) { item.StateId = 2; item.Name = "Syców"; _list.Add(item); };
            if (citytId == 48) { item.StateId = 2; item.Name = "Twardogóra"; _list.Add(item); };
            if (citytId == 49) { item.StateId = 2; item.Name = "Oława"; _list.Add(item); };
            if (citytId == 50) { item.StateId = 2; item.Name = "Jelcz-Laskowice"; _list.Add(item); };
            if (citytId == 51) { item.StateId = 2; item.Name = "Chocianów"; _list.Add(item); };
            if (citytId == 52) { item.StateId = 2; item.Name = "Polkowice"; _list.Add(item); };
            if (citytId == 53) { item.StateId = 2; item.Name = "Przemków"; _list.Add(item); };
            if (citytId == 54) { item.StateId = 2; item.Name = "Strzelin"; _list.Add(item); };
            if (citytId == 55) { item.StateId = 2; item.Name = "Wiązów"; _list.Add(item); };
            if (citytId == 56) { item.StateId = 2; item.Name = "Środa Śląska"; _list.Add(item); };
            if (citytId == 57) { item.StateId = 2; item.Name = "Świdnica"; _list.Add(item); };
            if (citytId == 58) { item.StateId = 2; item.Name = "Świebodzice"; _list.Add(item); };
            if (citytId == 59) { item.StateId = 2; item.Name = "Jaworzyna Śląska"; _list.Add(item); };
            if (citytId == 60) { item.StateId = 2; item.Name = "Strzegom"; _list.Add(item); };
            if (citytId == 61) { item.StateId = 2; item.Name = "Żarów"; _list.Add(item); };
            if (citytId == 62) { item.StateId = 2; item.Name = "Oborniki Śląskie"; _list.Add(item); };
            if (citytId == 63) { item.StateId = 2; item.Name = "Prusice"; _list.Add(item); };
            if (citytId == 64) { item.StateId = 2; item.Name = "Trzebnica"; _list.Add(item); };
            if (citytId == 65) { item.StateId = 2; item.Name = "Żmigród"; _list.Add(item); };
            if (citytId == 66) { item.StateId = 2; item.Name = "Boguszów-Gorce"; _list.Add(item); };
            if (citytId == 67) { item.StateId = 2; item.Name = "Jedlina-Zdrój"; _list.Add(item); };
            if (citytId == 68) { item.StateId = 2; item.Name = "Szczawno-Zdrój"; _list.Add(item); };
            if (citytId == 69) { item.StateId = 2; item.Name = "Głuszyca"; _list.Add(item); };
            if (citytId == 70) { item.StateId = 2; item.Name = "Mieroszów"; _list.Add(item); };
            if (citytId == 71) { item.StateId = 2; item.Name = "Brzeg Dolny"; _list.Add(item); };
            if (citytId == 72) { item.StateId = 2; item.Name = "Wołów"; _list.Add(item); };
            if (citytId == 73) { item.StateId = 2; item.Name = "Kąty Wrocławskie"; _list.Add(item); };
            if (citytId == 74) { item.StateId = 2; item.Name = "Sobótka"; _list.Add(item); };
            if (citytId == 75) { item.StateId = 2; item.Name = "Siechnice"; _list.Add(item); };
            if (citytId == 76) { item.StateId = 2; item.Name = "Bardo"; _list.Add(item); };
            if (citytId == 77) { item.StateId = 2; item.Name = "Ząbkowice Śląskie"; _list.Add(item); };
            if (citytId == 78) { item.StateId = 2; item.Name = "Ziębice"; _list.Add(item); };
            if (citytId == 79) { item.StateId = 2; item.Name = "Złoty Stok"; _list.Add(item); };
            if (citytId == 80) { item.StateId = 2; item.Name = "Zawidów"; _list.Add(item); };
            if (citytId == 81) { item.StateId = 2; item.Name = "Zgorzelec"; _list.Add(item); };
            if (citytId == 82) { item.StateId = 2; item.Name = "Bogatynia"; _list.Add(item); };
            if (citytId == 83) { item.StateId = 2; item.Name = "Pieńsk"; _list.Add(item); };
            if (citytId == 84) { item.StateId = 2; item.Name = "Węgliniec"; _list.Add(item); };
            if (citytId == 85) { item.StateId = 2; item.Name = "Wojcieszów"; _list.Add(item); };
            if (citytId == 86) { item.StateId = 2; item.Name = "Złotoryja"; _list.Add(item); };
            if (citytId == 87) { item.StateId = 2; item.Name = "Świerzawa"; _list.Add(item); };
            if (citytId == 88) { item.StateId = 2; item.Name = "Jelenia Góra"; _list.Add(item); };
            if (citytId == 89) { item.StateId = 2; item.Name = "Legnica"; _list.Add(item); };
            if (citytId == 90) { item.StateId = 2; item.Name = "Wrocław"; _list.Add(item); };
            if (citytId == 91) { item.StateId = 2; item.Name = "Wałbrzych"; _list.Add(item); };
            if (citytId == 92) { item.StateId = 4; item.Name = "Aleksandrów Kujawski"; _list.Add(item); };
            if (citytId == 93) { item.StateId = 4; item.Name = "Ciechocinek"; _list.Add(item); };
            if (citytId == 94) { item.StateId = 4; item.Name = "Nieszawa"; _list.Add(item); };
            if (citytId == 95) { item.StateId = 4; item.Name = "Brodnica"; _list.Add(item); };
            if (citytId == 96) { item.StateId = 4; item.Name = "Górzno"; _list.Add(item); };
            if (citytId == 97) { item.StateId = 4; item.Name = "Jabłonowo Pomorskie"; _list.Add(item); };
            if (citytId == 98) { item.StateId = 4; item.Name = "Koronowo"; _list.Add(item); };
            if (citytId == 99) { item.StateId = 4; item.Name = "Solec Kujawski"; _list.Add(item); };
            if (citytId == 100) { item.StateId = 4; item.Name = "Chełmno"; _list.Add(item); };
            if (citytId == 101) { item.StateId = 4; item.Name = "Golub-Dobrzyń"; _list.Add(item); };
            if (citytId == 102) { item.StateId = 4; item.Name = "Kowalewo Pomorskie"; _list.Add(item); };
            if (citytId == 103) { item.StateId = 4; item.Name = "Łasin"; _list.Add(item); };
            if (citytId == 104) { item.StateId = 4; item.Name = "Radzyń Chełmiński"; _list.Add(item); };
            if (citytId == 105) { item.StateId = 4; item.Name = "Inowrocław"; _list.Add(item); };
            if (citytId == 106) { item.StateId = 4; item.Name = "Gniewkowo"; _list.Add(item); };
            if (citytId == 107) { item.StateId = 4; item.Name = "Janikowo"; _list.Add(item); };
            if (citytId == 108) { item.StateId = 4; item.Name = "Kruszwica"; _list.Add(item); };
            if (citytId == 109) { item.StateId = 4; item.Name = "Pakość"; _list.Add(item); };
            if (citytId == 110) { item.StateId = 4; item.Name = "Lipno"; _list.Add(item); };
            if (citytId == 111) { item.StateId = 4; item.Name = "Dobrzyń nad Wisłą"; _list.Add(item); };
            if (citytId == 112) { item.StateId = 4; item.Name = "Skępe"; _list.Add(item); };
            if (citytId == 113) { item.StateId = 4; item.Name = "Mogilno"; _list.Add(item); };
            if (citytId == 114) { item.StateId = 4; item.Name = "Strzelno"; _list.Add(item); };
            if (citytId == 115) { item.StateId = 4; item.Name = "Kcynia"; _list.Add(item); };
            if (citytId == 116) { item.StateId = 4; item.Name = "Mrocza"; _list.Add(item); };
            if (citytId == 117) { item.StateId = 4; item.Name = "Nakło nad Notecią"; _list.Add(item); };
            if (citytId == 118) { item.StateId = 4; item.Name = "Szubin"; _list.Add(item); };
            if (citytId == 119) { item.StateId = 4; item.Name = "Radziejów"; _list.Add(item); };
            if (citytId == 120) { item.StateId = 4; item.Name = "Piotrków Kujawski"; _list.Add(item); };
            if (citytId == 121) { item.StateId = 4; item.Name = "Rypin"; _list.Add(item); };
            if (citytId == 122) { item.StateId = 4; item.Name = "Kamień Krajeński"; _list.Add(item); };
            if (citytId == 123) { item.StateId = 4; item.Name = "Sępólno Krajeńskie"; _list.Add(item); };
            if (citytId == 124) { item.StateId = 4; item.Name = "Więcbork"; _list.Add(item); };
            if (citytId == 125) { item.StateId = 4; item.Name = "Nowe"; _list.Add(item); };
            if (citytId == 126) { item.StateId = 4; item.Name = "Świecie"; _list.Add(item); };
            if (citytId == 127) { item.StateId = 4; item.Name = "Chełmża"; _list.Add(item); };
            if (citytId == 128) { item.StateId = 4; item.Name = "Tuchola"; _list.Add(item); };
            if (citytId == 129) { item.StateId = 4; item.Name = "Wąbrzeźno"; _list.Add(item); };
            if (citytId == 130) { item.StateId = 4; item.Name = "Kowal"; _list.Add(item); };
            if (citytId == 131) { item.StateId = 4; item.Name = "Brześć Kujawski"; _list.Add(item); };
            if (citytId == 132) { item.StateId = 4; item.Name = "Chodecz"; _list.Add(item); };
            if (citytId == 133) { item.StateId = 4; item.Name = "Izbica Kujawska"; _list.Add(item); };
            if (citytId == 134) { item.StateId = 4; item.Name = "Lubień Kujawski"; _list.Add(item); };
            if (citytId == 135) { item.StateId = 4; item.Name = "Lubraniec"; _list.Add(item); };
            if (citytId == 136) { item.StateId = 4; item.Name = "Barcin"; _list.Add(item); };
            if (citytId == 137) { item.StateId = 4; item.Name = "Janowiec Wielkopolski"; _list.Add(item); };
            if (citytId == 138) { item.StateId = 4; item.Name = "Łabiszyn"; _list.Add(item); };
            if (citytId == 139) { item.StateId = 4; item.Name = "Żnin"; _list.Add(item); };
            if (citytId == 140) { item.StateId = 4; item.Name = "Bydgoszcz"; _list.Add(item); };
            if (citytId == 141) { item.StateId = 4; item.Name = "Grudziądz"; _list.Add(item); };
            if (citytId == 142) { item.StateId = 4; item.Name = "Toruń"; _list.Add(item); };
            if (citytId == 143) { item.StateId = 4; item.Name = "Włocławek"; _list.Add(item); };
            if (citytId == 144) { item.StateId = 6; item.Name = "Międzyrzec Podlaski"; _list.Add(item); };
            if (citytId == 145) { item.StateId = 6; item.Name = "Terespol"; _list.Add(item); };
            if (citytId == 146) { item.StateId = 6; item.Name = "Biłgoraj"; _list.Add(item); };
            if (citytId == 147) { item.StateId = 6; item.Name = "Frampol"; _list.Add(item); };
            if (citytId == 148) { item.StateId = 6; item.Name = "Józefów"; _list.Add(item); };
            if (citytId == 149) { item.StateId = 6; item.Name = "Tarnogród"; _list.Add(item); };
            if (citytId == 150) { item.StateId = 6; item.Name = "Rejowiec Fabryczny"; _list.Add(item); };
            if (citytId == 151) { item.StateId = 6; item.Name = "Siedliszcze"; _list.Add(item); };
            if (citytId == 152) { item.StateId = 6; item.Name = "Hrubieszów"; _list.Add(item); };
            if (citytId == 153) { item.StateId = 6; item.Name = "Janów Lubelski"; _list.Add(item); };
            if (citytId == 154) { item.StateId = 6; item.Name = "Modliborzyce"; _list.Add(item); };
            if (citytId == 155) { item.StateId = 6; item.Name = "Krasnystaw"; _list.Add(item); };
            if (citytId == 156) { item.StateId = 6; item.Name = "Kraśnik"; _list.Add(item); };
            if (citytId == 157) { item.StateId = 6; item.Name = "Annopol"; _list.Add(item); };
            if (citytId == 158) { item.StateId = 6; item.Name = "Urzędów"; _list.Add(item); };
            if (citytId == 159) { item.StateId = 6; item.Name = "Lubartów"; _list.Add(item); };
            if (citytId == 160) { item.StateId = 6; item.Name = "Kock"; _list.Add(item); };
            if (citytId == 161) { item.StateId = 6; item.Name = "Ostrów Lubelski"; _list.Add(item); };
            if (citytId == 162) { item.StateId = 6; item.Name = "Bełżyce"; _list.Add(item); };
            if (citytId == 163) { item.StateId = 6; item.Name = "Bychawa"; _list.Add(item); };
            if (citytId == 164) { item.StateId = 6; item.Name = "Łęczna"; _list.Add(item); };
            if (citytId == 165) { item.StateId = 6; item.Name = "Łuków"; _list.Add(item); };
            if (citytId == 166) { item.StateId = 6; item.Name = "Stoczek Łukowski"; _list.Add(item); };
            if (citytId == 167) { item.StateId = 6; item.Name = "Opole Lubelskie"; _list.Add(item); };
            if (citytId == 168) { item.StateId = 6; item.Name = "Poniatowa"; _list.Add(item); };
            if (citytId == 169) { item.StateId = 6; item.Name = "Parczew"; _list.Add(item); };
            if (citytId == 170) { item.StateId = 6; item.Name = "Puławy"; _list.Add(item); };
            if (citytId == 171) { item.StateId = 6; item.Name = "Kazimierz Dolny"; _list.Add(item); };
            if (citytId == 172) { item.StateId = 6; item.Name = "Nałęczów"; _list.Add(item); };
            if (citytId == 173) { item.StateId = 6; item.Name = "Radzyń Podlaski"; _list.Add(item); };
            if (citytId == 174) { item.StateId = 6; item.Name = "Dęblin"; _list.Add(item); };
            if (citytId == 175) { item.StateId = 6; item.Name = "Ryki"; _list.Add(item); };
            if (citytId == 176) { item.StateId = 6; item.Name = "Świdnik"; _list.Add(item); };
            if (citytId == 177) { item.StateId = 6; item.Name = "Piaski"; _list.Add(item); };
            if (citytId == 178) { item.StateId = 6; item.Name = "Tomaszów Lubelski"; _list.Add(item); };
            if (citytId == 179) { item.StateId = 6; item.Name = "Lubycza Królewska"; _list.Add(item); };
            if (citytId == 180) { item.StateId = 6; item.Name = "Łaszczów"; _list.Add(item); };
            if (citytId == 181) { item.StateId = 6; item.Name = "Tyszowce"; _list.Add(item); };
            if (citytId == 182) { item.StateId = 6; item.Name = "Włodawa"; _list.Add(item); };
            if (citytId == 183) { item.StateId = 6; item.Name = "Krasnobród"; _list.Add(item); };
            if (citytId == 184) { item.StateId = 6; item.Name = "Szczebrzeszyn"; _list.Add(item); };
            if (citytId == 185) { item.StateId = 6; item.Name = "Zwierzyniec"; _list.Add(item); };
            if (citytId == 186) { item.StateId = 6; item.Name = "Biała Podlaska"; _list.Add(item); };
            if (citytId == 187) { item.StateId = 6; item.Name = "Chełm"; _list.Add(item); };
            if (citytId == 188) { item.StateId = 6; item.Name = "Lublin"; _list.Add(item); };
            if (citytId == 189) { item.StateId = 6; item.Name = "Zamość"; _list.Add(item); };
            if (citytId == 190) { item.StateId = 8; item.Name = "Kostrzyn nad Odrą"; _list.Add(item); };
            if (citytId == 191) { item.StateId = 8; item.Name = "Witnica"; _list.Add(item); };
            if (citytId == 192) { item.StateId = 8; item.Name = "Gubin"; _list.Add(item); };
            if (citytId == 193) { item.StateId = 8; item.Name = "Krosno Odrzańskie"; _list.Add(item); };
            if (citytId == 194) { item.StateId = 8; item.Name = "Międzyrzecz"; _list.Add(item); };
            if (citytId == 195) { item.StateId = 8; item.Name = "Skwierzyna"; _list.Add(item); };
            if (citytId == 196) { item.StateId = 8; item.Name = "Trzciel"; _list.Add(item); };
            if (citytId == 197) { item.StateId = 8; item.Name = "Nowa Sól"; _list.Add(item); };
            if (citytId == 198) { item.StateId = 8; item.Name = "Bytom Odrzański"; _list.Add(item); };
            if (citytId == 199) { item.StateId = 8; item.Name = "Kożuchów"; _list.Add(item); };
            if (citytId == 200) { item.StateId = 8; item.Name = "Nowe Miasteczko"; _list.Add(item); };
            if (citytId == 201) { item.StateId = 8; item.Name = "Cybinka"; _list.Add(item); };
            if (citytId == 202) { item.StateId = 8; item.Name = "Ośno Lubuskie"; _list.Add(item); };
            if (citytId == 203) { item.StateId = 8; item.Name = "Rzepin"; _list.Add(item); };
            if (citytId == 204) { item.StateId = 8; item.Name = "Słubice"; _list.Add(item); };
            if (citytId == 205) { item.StateId = 8; item.Name = "Dobiegniew"; _list.Add(item); };
            if (citytId == 206) { item.StateId = 8; item.Name = "Drezdenko"; _list.Add(item); };
            if (citytId == 207) { item.StateId = 8; item.Name = "Strzelce Krajeńskie"; _list.Add(item); };
            if (citytId == 208) { item.StateId = 8; item.Name = "Lubniewice"; _list.Add(item); };
            if (citytId == 209) { item.StateId = 8; item.Name = "Sulęcin"; _list.Add(item); };
            if (citytId == 210) { item.StateId = 8; item.Name = "Torzym"; _list.Add(item); };
            if (citytId == 211) { item.StateId = 8; item.Name = "Świebodzin"; _list.Add(item); };
            if (citytId == 212) { item.StateId = 8; item.Name = "Zbąszynek"; _list.Add(item); };
            if (citytId == 213) { item.StateId = 8; item.Name = "Babimost"; _list.Add(item); };
            if (citytId == 214) { item.StateId = 8; item.Name = "Czerwieńsk"; _list.Add(item); };
            if (citytId == 215) { item.StateId = 8; item.Name = "Kargowa"; _list.Add(item); };
            if (citytId == 216) { item.StateId = 8; item.Name = "Nowogród Bobrzański"; _list.Add(item); };
            if (citytId == 217) { item.StateId = 8; item.Name = "Sulechów"; _list.Add(item); };
            if (citytId == 218) { item.StateId = 8; item.Name = "Gozdnica"; _list.Add(item); };
            if (citytId == 219) { item.StateId = 8; item.Name = "Żagań"; _list.Add(item); };
            if (citytId == 220) { item.StateId = 8; item.Name = "Iłowa"; _list.Add(item); };
            if (citytId == 221) { item.StateId = 8; item.Name = "Małomice"; _list.Add(item); };
            if (citytId == 222) { item.StateId = 8; item.Name = "Szprotawa"; _list.Add(item); };
            if (citytId == 223) { item.StateId = 8; item.Name = "Łęknica"; _list.Add(item); };
            if (citytId == 224) { item.StateId = 8; item.Name = "Żary"; _list.Add(item); };
            if (citytId == 225) { item.StateId = 8; item.Name = "Jasień"; _list.Add(item); };
            if (citytId == 226) { item.StateId = 8; item.Name = "Lubsko"; _list.Add(item); };
            if (citytId == 227) { item.StateId = 8; item.Name = "Sława"; _list.Add(item); };
            if (citytId == 228) { item.StateId = 8; item.Name = "Szlichtyngowa"; _list.Add(item); };
            if (citytId == 229) { item.StateId = 8; item.Name = "Wschowa"; _list.Add(item); };
            if (citytId == 230) { item.StateId = 8; item.Name = "Gorzów Wielkopolski"; _list.Add(item); };
            if (citytId == 231) { item.StateId = 8; item.Name = "Zielona Góra"; _list.Add(item); };
            if (citytId == 232) { item.StateId = 10; item.Name = "Bełchatów"; _list.Add(item); };
            if (citytId == 233) { item.StateId = 10; item.Name = "Zelów"; _list.Add(item); };
            if (citytId == 234) { item.StateId = 10; item.Name = "Kutno"; _list.Add(item); };
            if (citytId == 235) { item.StateId = 10; item.Name = "Krośniewice"; _list.Add(item); };
            if (citytId == 236) { item.StateId = 10; item.Name = "Żychlin"; _list.Add(item); };
            if (citytId == 237) { item.StateId = 10; item.Name = "Łask"; _list.Add(item); };
            if (citytId == 238) { item.StateId = 10; item.Name = "Łęczyca"; _list.Add(item); };
            if (citytId == 239) { item.StateId = 10; item.Name = "Łowicz"; _list.Add(item); };
            if (citytId == 240) { item.StateId = 10; item.Name = "Koluszki"; _list.Add(item); };
            if (citytId == 241) { item.StateId = 10; item.Name = "Rzgów"; _list.Add(item); };
            if (citytId == 242) { item.StateId = 10; item.Name = "Tuszyn"; _list.Add(item); };
            if (citytId == 243) { item.StateId = 10; item.Name = "Drzewica"; _list.Add(item); };
            if (citytId == 244) { item.StateId = 10; item.Name = "Opoczno"; _list.Add(item); };
            if (citytId == 245) { item.StateId = 10; item.Name = "Konstantynów Łódzki"; _list.Add(item); };
            if (citytId == 246) { item.StateId = 10; item.Name = "Pabianice"; _list.Add(item); };
            if (citytId == 247) { item.StateId = 10; item.Name = "Działoszyn"; _list.Add(item); };
            if (citytId == 248) { item.StateId = 10; item.Name = "Pajęczno"; _list.Add(item); };
            if (citytId == 249) { item.StateId = 10; item.Name = "Sulejów"; _list.Add(item); };
            if (citytId == 250) { item.StateId = 10; item.Name = "Wolbórz"; _list.Add(item); };
            if (citytId == 251) { item.StateId = 10; item.Name = "Poddębice"; _list.Add(item); };
            if (citytId == 252) { item.StateId = 10; item.Name = "Uniejów"; _list.Add(item); };
            if (citytId == 253) { item.StateId = 10; item.Name = "Radomsko"; _list.Add(item); };
            if (citytId == 254) { item.StateId = 10; item.Name = "Kamieńsk"; _list.Add(item); };
            if (citytId == 255) { item.StateId = 10; item.Name = "Przedbórz"; _list.Add(item); };
            if (citytId == 256) { item.StateId = 10; item.Name = "Rawa Mazowiecka"; _list.Add(item); };
            if (citytId == 257) { item.StateId = 10; item.Name = "Biała Rawska"; _list.Add(item); };
            if (citytId == 258) { item.StateId = 10; item.Name = "Sieradz"; _list.Add(item); };
            if (citytId == 259) { item.StateId = 10; item.Name = "Błaszki"; _list.Add(item); };
            if (citytId == 260) { item.StateId = 10; item.Name = "Warta"; _list.Add(item); };
            if (citytId == 261) { item.StateId = 10; item.Name = "Złoczew"; _list.Add(item); };
            if (citytId == 262) { item.StateId = 10; item.Name = "Tomaszów Mazowiecki"; _list.Add(item); };
            if (citytId == 263) { item.StateId = 10; item.Name = "Wieluń"; _list.Add(item); };
            if (citytId == 264) { item.StateId = 10; item.Name = "Wieruszów"; _list.Add(item); };
            if (citytId == 265) { item.StateId = 10; item.Name = "Zduńska Wola"; _list.Add(item); };
            if (citytId == 266) { item.StateId = 10; item.Name = "Szadek"; _list.Add(item); };
            if (citytId == 267) { item.StateId = 10; item.Name = "Głowno"; _list.Add(item); };
            if (citytId == 268) { item.StateId = 10; item.Name = "Ozorków"; _list.Add(item); };
            if (citytId == 269) { item.StateId = 10; item.Name = "Zgierz"; _list.Add(item); };
            if (citytId == 270) { item.StateId = 10; item.Name = "Aleksandrów Łódzki"; _list.Add(item); };
            if (citytId == 271) { item.StateId = 10; item.Name = "Stryków"; _list.Add(item); };
            if (citytId == 272) { item.StateId = 10; item.Name = "Brzeziny"; _list.Add(item); };
            if (citytId == 273) { item.StateId = 10; item.Name = "Łódź"; _list.Add(item); };
            if (citytId == 274) { item.StateId = 10; item.Name = "Piotrków Trybunalski"; _list.Add(item); };
            if (citytId == 275) { item.StateId = 10; item.Name = "Skierniewice"; _list.Add(item); };
            if (citytId == 276) { item.StateId = 12; item.Name = "Bochnia"; _list.Add(item); };
            if (citytId == 277) { item.StateId = 12; item.Name = "Nowy Wiśnicz"; _list.Add(item); };
            if (citytId == 278) { item.StateId = 12; item.Name = "Brzesko"; _list.Add(item); };
            if (citytId == 279) { item.StateId = 12; item.Name = "Czchów"; _list.Add(item); };
            if (citytId == 280) { item.StateId = 12; item.Name = "Alwernia"; _list.Add(item); };
            if (citytId == 281) { item.StateId = 12; item.Name = "Chrzanów"; _list.Add(item); };
            if (citytId == 282) { item.StateId = 12; item.Name = "Libiąż"; _list.Add(item); };
            if (citytId == 283) { item.StateId = 12; item.Name = "Trzebinia"; _list.Add(item); };
            if (citytId == 284) { item.StateId = 12; item.Name = "Dąbrowa Tarnowska"; _list.Add(item); };
            if (citytId == 285) { item.StateId = 12; item.Name = "Szczucin"; _list.Add(item); };
            if (citytId == 286) { item.StateId = 12; item.Name = "Gorlice"; _list.Add(item); };
            if (citytId == 287) { item.StateId = 12; item.Name = "Biecz"; _list.Add(item); };
            if (citytId == 288) { item.StateId = 12; item.Name = "Bobowa"; _list.Add(item); };
            if (citytId == 289) { item.StateId = 12; item.Name = "Krzeszowice"; _list.Add(item); };
            if (citytId == 290) { item.StateId = 12; item.Name = "Skała"; _list.Add(item); };
            if (citytId == 291) { item.StateId = 12; item.Name = "Skawina"; _list.Add(item); };
            if (citytId == 292) { item.StateId = 12; item.Name = "Słomniki"; _list.Add(item); };
            if (citytId == 293) { item.StateId = 12; item.Name = "Świątniki Górne"; _list.Add(item); };
            if (citytId == 294) { item.StateId = 12; item.Name = "Limanowa"; _list.Add(item); };
            if (citytId == 295) { item.StateId = 12; item.Name = "Mszana Dolna"; _list.Add(item); };
            if (citytId == 296) { item.StateId = 12; item.Name = "Miechów"; _list.Add(item); };
            if (citytId == 297) { item.StateId = 12; item.Name = "Dobczyce"; _list.Add(item); };
            if (citytId == 298) { item.StateId = 12; item.Name = "Myślenice"; _list.Add(item); };
            if (citytId == 299) { item.StateId = 12; item.Name = "Sułkowice"; _list.Add(item); };
            if (citytId == 300) { item.StateId = 12; item.Name = "Grybów"; _list.Add(item); };
            if (citytId == 301) { item.StateId = 12; item.Name = "Krynica-Zdrój"; _list.Add(item); };
            if (citytId == 302) { item.StateId = 12; item.Name = "Muszyna"; _list.Add(item); };
            if (citytId == 303) { item.StateId = 12; item.Name = "Piwniczna-Zdrój"; _list.Add(item); };
            if (citytId == 304) { item.StateId = 12; item.Name = "Stary Sącz"; _list.Add(item); };
            if (citytId == 305) { item.StateId = 12; item.Name = "Nowy Targ"; _list.Add(item); };
            if (citytId == 306) { item.StateId = 12; item.Name = "Szczawnica"; _list.Add(item); };
            if (citytId == 307) { item.StateId = 12; item.Name = "Rabka-Zdrój"; _list.Add(item); };
            if (citytId == 308) { item.StateId = 12; item.Name = "Bukowno"; _list.Add(item); };
            if (citytId == 309) { item.StateId = 12; item.Name = "Olkusz"; _list.Add(item); };
            if (citytId == 310) { item.StateId = 12; item.Name = "Wolbrom"; _list.Add(item); };
            if (citytId == 311) { item.StateId = 12; item.Name = "Oświęcim"; _list.Add(item); };
            if (citytId == 312) { item.StateId = 12; item.Name = "Brzeszcze"; _list.Add(item); };
            if (citytId == 313) { item.StateId = 12; item.Name = "Chełmek"; _list.Add(item); };
            if (citytId == 314) { item.StateId = 12; item.Name = "Kęty"; _list.Add(item); };
            if (citytId == 315) { item.StateId = 12; item.Name = "Zator"; _list.Add(item); };
            if (citytId == 316) { item.StateId = 12; item.Name = "Nowe Brzesko"; _list.Add(item); };
            if (citytId == 317) { item.StateId = 12; item.Name = "Proszowice"; _list.Add(item); };
            if (citytId == 318) { item.StateId = 12; item.Name = "Jordanów"; _list.Add(item); };
            if (citytId == 319) { item.StateId = 12; item.Name = "Sucha Beskidzka"; _list.Add(item); };
            if (citytId == 320) { item.StateId = 12; item.Name = "Maków Podhalański"; _list.Add(item); };
            if (citytId == 321) { item.StateId = 12; item.Name = "Ciężkowice"; _list.Add(item); };
            if (citytId == 322) { item.StateId = 12; item.Name = "Radłów"; _list.Add(item); };
            if (citytId == 323) { item.StateId = 12; item.Name = "Ryglice"; _list.Add(item); };
            if (citytId == 324) { item.StateId = 12; item.Name = "Tuchów"; _list.Add(item); };
            if (citytId == 325) { item.StateId = 12; item.Name = "Wojnicz"; _list.Add(item); };
            if (citytId == 326) { item.StateId = 12; item.Name = "Zakliczyn"; _list.Add(item); };
            if (citytId == 327) { item.StateId = 12; item.Name = "Żabno"; _list.Add(item); };
            if (citytId == 328) { item.StateId = 12; item.Name = "Zakopane"; _list.Add(item); }; ///błąd w dodawaniu
            if (citytId == 329) { item.StateId = 12; item.Name = "Andrychów"; _list.Add(item); };
            if (citytId == 330) { item.StateId = 12; item.Name = "Kalwaria Zebrzydowska"; _list.Add(item); };
            if (citytId == 331) { item.StateId = 12; item.Name = "Wadowice"; _list.Add(item); }; ///błąd w dodawaniu
            if (citytId == 332) { item.StateId = 12; item.Name = "Niepołomice"; _list.Add(item); };
            if (citytId == 333) { item.StateId = 12; item.Name = "Wieliczka"; _list.Add(item); };
            if (citytId == 334) { item.StateId = 12; item.Name = "Kraków"; _list.Add(item); };
            if (citytId == 335) { item.StateId = 12; item.Name = "Nowy Sącz"; _list.Add(item); };
            if (citytId == 336) { item.StateId = 12; item.Name = "Tarnów"; _list.Add(item); };
            if (citytId == 337) { item.StateId = 14; item.Name = "Białobrzegi"; _list.Add(item); }; ///błąd w dodawaniu
            if (citytId == 338) { item.StateId = 14; item.Name = "Wyśmierzyce"; _list.Add(item); }; ///błąd w dodawaniu
            if (citytId == 339) { item.StateId = 14; item.Name = "Ciechanów"; _list.Add(item); }; ///błąd w dodawaniu
            if (citytId == 340) { item.StateId = 14; item.Name = "Glinojeck"; _list.Add(item); };
            if (citytId == 341) { item.StateId = 14; item.Name = "Garwolin"; _list.Add(item); };
            if (citytId == 342) { item.StateId = 14; item.Name = "Łaskarzew"; _list.Add(item); };
            if (citytId == 343) { item.StateId = 14; item.Name = "Pilawa"; _list.Add(item); };
            if (citytId == 344) { item.StateId = 14; item.Name = "Żelechów"; _list.Add(item); };
            if (citytId == 345) { item.StateId = 14; item.Name = "Gostynin"; _list.Add(item); };
            if (citytId == 346) { item.StateId = 14; item.Name = "Milanówek"; _list.Add(item); };///błąd w dodawaniu
            if (citytId == 347) { item.StateId = 14; item.Name = "Podkowa Leśna"; _list.Add(item); };
            if (citytId == 348) { item.StateId = 14; item.Name = "Grodzisk Mazowiecki"; _list.Add(item); };
            if (citytId == 349) { item.StateId = 14; item.Name = "Grójec"; _list.Add(item); };///błąd w dodawaniu
            if (citytId == 350) { item.StateId = 14; item.Name = "Mogielnica"; _list.Add(item); };
            if (citytId == 351) { item.StateId = 14; item.Name = "Nowe Miasto nad Pilicą"; _list.Add(item); };
            if (citytId == 352) { item.StateId = 14; item.Name = "Warka"; _list.Add(item); };
            if (citytId == 353) { item.StateId = 14; item.Name = "Kozienice"; _list.Add(item); };///błąd w dodawaniu     ///do 500
            if (citytId == 354) { item.StateId = 14; item.Name = "Legionowo"; _list.Add(item); };
            if (citytId == 355) { item.StateId = 14; item.Name = "Serock"; _list.Add(item); };
            if (citytId == 356) { item.StateId = 14; item.Name = "Lipsko"; _list.Add(item); };
            if (citytId == 357) { item.StateId = 14; item.Name = "Łosice"; _list.Add(item); };
            if (citytId == 358) { item.StateId = 14; item.Name = "Maków Mazowiecki"; _list.Add(item); };
            if (citytId == 359) { item.StateId = 14; item.Name = "Różan"; _list.Add(item); }; //błąd w dodawaniu
            if (citytId == 360) { item.StateId = 14; item.Name = "Mińsk Mazowiecki"; _list.Add(item); };
            if (citytId == 361) { item.StateId = 14; item.Name = "Halinów"; _list.Add(item); };
            if (citytId == 362) { item.StateId = 14; item.Name = "Kałuszyn"; _list.Add(item); }; //błąd w dodawaniu
            if (citytId == 363) { item.StateId = 14; item.Name = "Mrozy"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 364) { item.StateId = 14; item.Name = "Sulejówek"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 365) { item.StateId = 14; item.Name = "Mława"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 366) { item.StateId = 14; item.Name = "Nowy Dwór Mazowiecki"; _list.Add(item); };
            if (citytId == 367) { item.StateId = 14; item.Name = "Nasielsk"; _list.Add(item); };
            if (citytId == 368) { item.StateId = 14; item.Name = "Zakroczym"; _list.Add(item); };
            if (citytId == 369) { item.StateId = 14; item.Name = "Myszyniec"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 370) { item.StateId = 14; item.Name = "Ostrów Mazowiecka"; _list.Add(item); };
            if (citytId == 371) { item.StateId = 14; item.Name = "Brok"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 372) { item.StateId = 14; item.Name = "Józefów"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 373) { item.StateId = 14; item.Name = "Otwock"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 374) { item.StateId = 14; item.Name = "Karczew"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 375) { item.StateId = 14; item.Name = "Góra Kalwaria"; _list.Add(item); };
            if (citytId == 376) { item.StateId = 14; item.Name = "Konstancin-Jeziorna"; _list.Add(item); };
            if (citytId == 377) { item.StateId = 14; item.Name = "Piaseczno"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 378) { item.StateId = 14; item.Name = "Tarczyn"; _list.Add(item); };
            if (citytId == 379) { item.StateId = 14; item.Name = "Drobin"; _list.Add(item); };
            if (citytId == 380) { item.StateId = 14; item.Name = "Gąbin"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 381) { item.StateId = 14; item.Name = "Wyszogród"; _list.Add(item); };
            if (citytId == 382) { item.StateId = 14; item.Name = "Płońsk"; _list.Add(item); };
            if (citytId == 383) { item.StateId = 14; item.Name = "Raciąż"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 384) { item.StateId = 14; item.Name = "Piastów"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 385) { item.StateId = 14; item.Name = "Pruszków"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 386) { item.StateId = 14; item.Name = "Brwinów"; _list.Add(item); };
            if (citytId == 387) { item.StateId = 14; item.Name = "Przasnysz"; _list.Add(item); };
            if (citytId == 388) { item.StateId = 14; item.Name = "Chorzele"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 389) { item.StateId = 14; item.Name = "Przysucha"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 390) { item.StateId = 14; item.Name = "Pułtusk"; _list.Add(item); };
            if (citytId == 391) { item.StateId = 14; item.Name = "Pionki"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 392) { item.StateId = 14; item.Name = "Iłża"; _list.Add(item); };
            if (citytId == 393) { item.StateId = 14; item.Name = "Skaryszew"; _list.Add(item); };
            if (citytId == 394) { item.StateId = 14; item.Name = "Mordy"; _list.Add(item); };
            if (citytId == 395) { item.StateId = 14; item.Name = "Sierpc"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 396) { item.StateId = 14; item.Name = "Sochaczew"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 397) { item.StateId = 14; item.Name = "Sokołów Podlaski"; _list.Add(item); };
            if (citytId == 398) { item.StateId = 14; item.Name = "Kosów Lacki"; _list.Add(item); };
            if (citytId == 399) { item.StateId = 14; item.Name = "Szydłowiec"; _list.Add(item); };
            if (citytId == 400) { item.StateId = 14; item.Name = "Błonie"; _list.Add(item); };
            if (citytId == 401) { item.StateId = 14; item.Name = "Łomianki"; _list.Add(item); };
            if (citytId == 402) { item.StateId = 14; item.Name = "Ożarów Mazowiecki"; _list.Add(item); };
            if (citytId == 403) { item.StateId = 14; item.Name = "Węgrów"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 404) { item.StateId = 14; item.Name = "Łochów"; _list.Add(item); };
            if (citytId == 405) { item.StateId = 14; item.Name = "Kobyłka"; _list.Add(item); };
            if (citytId == 406) { item.StateId = 14; item.Name = "Marki"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 407) { item.StateId = 14; item.Name = "Ząbki"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 408) { item.StateId = 14; item.Name = "Zielonka"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 409) { item.StateId = 14; item.Name = "Radzymin"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 410) { item.StateId = 14; item.Name = "Tłuszcz"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 411) { item.StateId = 14; item.Name = "Wołomin"; _list.Add(item); };
            if (citytId == 412) { item.StateId = 14; item.Name = "Wyszków"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 413) { item.StateId = 14; item.Name = "Zwoleń"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 414) { item.StateId = 14; item.Name = "Bieżuń"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 415) { item.StateId = 14; item.Name = "Żuromin"; _list.Add(item); };
            if (citytId == 416) { item.StateId = 14; item.Name = "Żyrardów"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 417) { item.StateId = 14; item.Name = "Mszczonów"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 418) { item.StateId = 14; item.Name = "Ostrołęka"; _list.Add(item); };//błąd w dodawaniu
            if (citytId == 419) { item.StateId = 14; item.Name = "Płock"; _list.Add(item); };
            if (citytId == 420) { item.StateId = 14; item.Name = "Radom"; _list.Add(item); };
            if (citytId == 421) { item.StateId = 14; item.Name = "Siedlce"; _list.Add(item); };
            if (citytId == 422) { item.StateId = 16; item.Name = "Brzeg"; _list.Add(item); };
            if (citytId == 423) { item.StateId = 16; item.Name = "Grodków"; _list.Add(item); };
            if (citytId == 424) { item.StateId = 16; item.Name = "Lewin Brzeski"; _list.Add(item); };
            if (citytId == 425) { item.StateId = 16; item.Name = "Baborów"; _list.Add(item); };
            if (citytId == 426) { item.StateId = 16; item.Name = "Głubczyce"; _list.Add(item); };
            if (citytId == 427) { item.StateId = 16; item.Name = "Kietrz"; _list.Add(item); };
            if (citytId == 428) { item.StateId = 16; item.Name = "Kędzierzyn-Koźle"; _list.Add(item); };
            if (citytId == 429) { item.StateId = 16; item.Name = "Byczyna"; _list.Add(item); };
            if (citytId == 430) { item.StateId = 16; item.Name = "Kluczbork"; _list.Add(item); };
            if (citytId == 431) { item.StateId = 16; item.Name = "Wołczyn"; _list.Add(item); };
            if (citytId == 432) { item.StateId = 16; item.Name = "Gogolin"; _list.Add(item); };
            if (citytId == 433) { item.StateId = 16; item.Name = "Krapkowice"; _list.Add(item); };
            if (citytId == 434) { item.StateId = 16; item.Name = "Zdzieszowice"; _list.Add(item); };
            if (citytId == 435) { item.StateId = 16; item.Name = "Namysłów"; _list.Add(item); };
            if (citytId == 436) { item.StateId = 16; item.Name = "Głuchołazy"; _list.Add(item); };
            if (citytId == 437) { item.StateId = 16; item.Name = "Korfantów"; _list.Add(item); };
            if (citytId == 438) { item.StateId = 16; item.Name = "Nysa"; _list.Add(item); };
            if (citytId == 439) { item.StateId = 16; item.Name = "Otmuchów"; _list.Add(item); };
            if (citytId == 440) { item.StateId = 16; item.Name = "Paczków"; _list.Add(item); };
            if (citytId == 441) { item.StateId = 16; item.Name = "Dobrodzień"; _list.Add(item); };
            if (citytId == 442) { item.StateId = 16; item.Name = "Gorzów Śląski"; _list.Add(item); };
            if (citytId == 443) { item.StateId = 16; item.Name = "Olesno"; _list.Add(item); };
            if (citytId == 444) { item.StateId = 16; item.Name = "Praszka"; _list.Add(item); };
            if (citytId == 445) { item.StateId = 16; item.Name = "Niemodlin"; _list.Add(item); };
            if (citytId == 446) { item.StateId = 16; item.Name = "Ozimek"; _list.Add(item); };
            if (citytId == 447) { item.StateId = 16; item.Name = "Prószków"; _list.Add(item); };
            if (citytId == 448) { item.StateId = 16; item.Name = "Biała"; _list.Add(item); };
            if (citytId == 449) { item.StateId = 16; item.Name = "Głogówek"; _list.Add(item); };
            if (citytId == 450) { item.StateId = 16; item.Name = "Prudnik"; _list.Add(item); };
            if (citytId == 451) { item.StateId = 16; item.Name = "Kolonowskie"; _list.Add(item); };
            if (citytId == 452) { item.StateId = 16; item.Name = "Leśnica"; _list.Add(item); };
            if (citytId == 453) { item.StateId = 16; item.Name = "Strzelce Opolskie"; _list.Add(item); };
            if (citytId == 454) { item.StateId = 16; item.Name = "Ujazd"; _list.Add(item); };
            if (citytId == 455) { item.StateId = 16; item.Name = "Zawadzkie"; _list.Add(item); };
            if (citytId == 456) { item.StateId = 16; item.Name = "Opole"; _list.Add(item); };
            if (citytId == 457) { item.StateId = 18; item.Name = "Ustrzyki Dolne"; _list.Add(item); };
            if (citytId == 458) { item.StateId = 18; item.Name = "Brzozów"; _list.Add(item); };
            if (citytId == 459) { item.StateId = 18; item.Name = "Dębica"; _list.Add(item); };
            if (citytId == 460) { item.StateId = 18; item.Name = "Brzostek"; _list.Add(item); };
            if (citytId == 461) { item.StateId = 18; item.Name = "Pilzno"; _list.Add(item); };
            if (citytId == 462) { item.StateId = 18; item.Name = "Jarosław"; _list.Add(item); };
            if (citytId == 463) { item.StateId = 18; item.Name = "Radymno"; _list.Add(item); };
            if (citytId == 464) { item.StateId = 18; item.Name = "Pruchnik"; _list.Add(item); };
            if (citytId == 465) { item.StateId = 18; item.Name = "Jasło"; _list.Add(item); };
            if (citytId == 466) { item.StateId = 18; item.Name = "Kołaczyce"; _list.Add(item); };
            if (citytId == 467) { item.StateId = 18; item.Name = "Kolbuszowa"; _list.Add(item); };
            if (citytId == 468) { item.StateId = 18; item.Name = "Dukla"; _list.Add(item); };
            if (citytId == 469) { item.StateId = 18; item.Name = "Iwonicz-Zdrój"; _list.Add(item); };
            if (citytId == 470) { item.StateId = 18; item.Name = "Jedlicze"; _list.Add(item); };
            if (citytId == 471) { item.StateId = 18; item.Name = "Rymanów"; _list.Add(item); };
            if (citytId == 472) { item.StateId = 18; item.Name = "Leżajsk"; _list.Add(item); };
            if (citytId == 473) { item.StateId = 18; item.Name = "Nowa Sarzyna"; _list.Add(item); };
            if (citytId == 474) { item.StateId = 18; item.Name = "Lubaczów"; _list.Add(item); };
            if (citytId == 475) { item.StateId = 18; item.Name = "Cieszanów"; _list.Add(item); };
            if (citytId == 476) { item.StateId = 18; item.Name = "Narol"; _list.Add(item); };
            if (citytId == 477) { item.StateId = 18; item.Name = "Oleszyce"; _list.Add(item); };
            if (citytId == 478) { item.StateId = 18; item.Name = "Łańcut"; _list.Add(item); };
            if (citytId == 479) { item.StateId = 18; item.Name = "Mielec"; _list.Add(item); };
            if (citytId == 480) { item.StateId = 18; item.Name = "Przecław"; _list.Add(item); };
            if (citytId == 481) { item.StateId = 18; item.Name = "Radomyśl Wielki"; _list.Add(item); };
            if (citytId == 482) { item.StateId = 18; item.Name = "Nisko"; _list.Add(item); };
            if (citytId == 483) { item.StateId = 18; item.Name = "Rudnik nad Sanem"; _list.Add(item); };
            if (citytId == 484) { item.StateId = 18; item.Name = "Ulanów"; _list.Add(item); };
            if (citytId == 485) { item.StateId = 18; item.Name = "Przeworsk"; _list.Add(item); };
            if (citytId == 486) { item.StateId = 18; item.Name = "Kańczuga"; _list.Add(item); };
            if (citytId == 487) { item.StateId = 18; item.Name = "Sieniawa"; _list.Add(item); };
            if (citytId == 488) { item.StateId = 18; item.Name = "Ropczyce"; _list.Add(item); };
            if (citytId == 489) { item.StateId = 18; item.Name = "Sędziszów Małopolski"; _list.Add(item); };
            if (citytId == 490) { item.StateId = 18; item.Name = "Dynów"; _list.Add(item); };
            if (citytId == 491) { item.StateId = 18; item.Name = "Błażowa"; _list.Add(item); };
            if (citytId == 492) { item.StateId = 18; item.Name = "Boguchwała"; _list.Add(item); };
            if (citytId == 493) { item.StateId = 18; item.Name = "Głogów Małopolski"; _list.Add(item); };
            if (citytId == 494) { item.StateId = 18; item.Name = "Sokołów Małopolski"; _list.Add(item); };
            if (citytId == 495) { item.StateId = 18; item.Name = "Tyczyn"; _list.Add(item); };
            if (citytId == 496) { item.StateId = 18; item.Name = "Sanok"; _list.Add(item); };
            if (citytId == 497) { item.StateId = 18; item.Name = "Zagórz"; _list.Add(item); };
            if (citytId == 498) { item.StateId = 18; item.Name = "Stalowa Wola"; _list.Add(item); };
            if (citytId == 499) { item.StateId = 18; item.Name = "Zaklików"; _list.Add(item); };
            if (citytId == 500) { item.StateId = 18; item.Name = "Strzyżów"; _list.Add(item); };
            if (citytId == 501) { item.StateId = 18; item.Name = "Baranów Sandomierski"; _list.Add(item); };
            if (citytId == 502) { item.StateId = 18; item.Name = "Nowa Dęba"; _list.Add(item); };
            if (citytId == 503) { item.StateId = 18; item.Name = "Lesko"; _list.Add(item); };
            if (citytId == 504) { item.StateId = 18; item.Name = "Krosno"; _list.Add(item); };
            if (citytId == 505) { item.StateId = 18; item.Name = "Przemyśl"; _list.Add(item); };
            if (citytId == 506) { item.StateId = 18; item.Name = "Rzeszów"; _list.Add(item); };
            if (citytId == 507) { item.StateId = 18; item.Name = "Tarnobrzeg"; _list.Add(item); };
            if (citytId == 508) { item.StateId = 20; item.Name = "Augustów"; _list.Add(item); };
            if (citytId == 509) { item.StateId = 20; item.Name = "Lipsk"; _list.Add(item); };
            if (citytId == 510) { item.StateId = 20; item.Name = "Choroszcz"; _list.Add(item); };
            if (citytId == 511) { item.StateId = 20; item.Name = "Czarna Białostocka"; _list.Add(item); };
            if (citytId == 512) { item.StateId = 20; item.Name = "Łapy"; _list.Add(item); };
            if (citytId == 513) { item.StateId = 20; item.Name = "Michałowo"; _list.Add(item); };
            if (citytId == 514) { item.StateId = 20; item.Name = "Supraśl"; _list.Add(item); };
            if (citytId == 515) { item.StateId = 20; item.Name = "Suraż"; _list.Add(item); };
            if (citytId == 516) { item.StateId = 20; item.Name = "Tykocin"; _list.Add(item); };
            if (citytId == 517) { item.StateId = 20; item.Name = "Wasilków"; _list.Add(item); };
            if (citytId == 518) { item.StateId = 20; item.Name = "Zabłudów"; _list.Add(item); };
            if (citytId == 519) { item.StateId = 20; item.Name = "Bielsk Podlaski"; _list.Add(item); };
            if (citytId == 520) { item.StateId = 20; item.Name = "Brańsk"; _list.Add(item); };
            if (citytId == 521) { item.StateId = 20; item.Name = "Grajewo"; _list.Add(item); };
            if (citytId == 522) { item.StateId = 20; item.Name = "Rajgród"; _list.Add(item); };
            if (citytId == 523) { item.StateId = 20; item.Name = "Szczuczyn"; _list.Add(item); };
            if (citytId == 524) { item.StateId = 20; item.Name = "Hajnówka"; _list.Add(item); };
            if (citytId == 525) { item.StateId = 20; item.Name = "Kleszczele"; _list.Add(item); };
            if (citytId == 526) { item.StateId = 20; item.Name = "Kolno"; _list.Add(item); };
            if (citytId == 527) { item.StateId = 20; item.Name = "Stawiski"; _list.Add(item); };
            if (citytId == 528) { item.StateId = 20; item.Name = "Jedwabne"; _list.Add(item); };
            if (citytId == 529) { item.StateId = 20; item.Name = "Nowogród"; _list.Add(item); };
            if (citytId == 530) { item.StateId = 20; item.Name = "Goniądz"; _list.Add(item); };
            if (citytId == 531) { item.StateId = 20; item.Name = "Knyszyn"; _list.Add(item); };
            if (citytId == 532) { item.StateId = 20; item.Name = "Mońki"; _list.Add(item); };
            if (citytId == 533) { item.StateId = 20; item.Name = "Sejny"; _list.Add(item); };
            if (citytId == 534) { item.StateId = 20; item.Name = "Siemiatycze"; _list.Add(item); };
            if (citytId == 535) { item.StateId = 20; item.Name = "Drohiczyn"; _list.Add(item); };
            if (citytId == 536) { item.StateId = 20; item.Name = "Dąbrowa Białostocka"; _list.Add(item); };
            if (citytId == 537) { item.StateId = 20; item.Name = "Krynki"; _list.Add(item); };
            if (citytId == 538) { item.StateId = 20; item.Name = "Sokółka"; _list.Add(item); };
            if (citytId == 539) { item.StateId = 20; item.Name = "Suchowola"; _list.Add(item); };
            if (citytId == 540) { item.StateId = 20; item.Name = "Wysokie Mazowieckie"; _list.Add(item); };
            if (citytId == 541) { item.StateId = 20; item.Name = "Ciechanowiec"; _list.Add(item); };
            if (citytId == 542) { item.StateId = 20; item.Name = "Czyżew"; _list.Add(item); };
            if (citytId == 543) { item.StateId = 20; item.Name = "Szepietowo"; _list.Add(item); };
            if (citytId == 544) { item.StateId = 20; item.Name = "Zambrów"; _list.Add(item); };
            if (citytId == 545) { item.StateId = 20; item.Name = "Białystok"; _list.Add(item); };
            if (citytId == 546) { item.StateId = 20; item.Name = "Łomża"; _list.Add(item); };
            if (citytId == 547) { item.StateId = 20; item.Name = "Suwałki"; _list.Add(item); };
            if (citytId == 548) { item.StateId = 22; item.Name = "Bytów"; _list.Add(item); };
            if (citytId == 549) { item.StateId = 22; item.Name = "Miastko"; _list.Add(item); };
            if (citytId == 550) { item.StateId = 22; item.Name = "Chojnice"; _list.Add(item); };
            if (citytId == 551) { item.StateId = 22; item.Name = "Brusy"; _list.Add(item); };
            if (citytId == 552) { item.StateId = 22; item.Name = "Czersk"; _list.Add(item); };
            if (citytId == 553) { item.StateId = 22; item.Name = "Człuchów"; _list.Add(item); };
            if (citytId == 554) { item.StateId = 22; item.Name = "Czarne"; _list.Add(item); };
            if (citytId == 555) { item.StateId = 22; item.Name = "Debrzno"; _list.Add(item); };
            if (citytId == 556) { item.StateId = 22; item.Name = "Pruszcz Gdański"; _list.Add(item); };
            if (citytId == 557) { item.StateId = 22; item.Name = "Kartuzy"; _list.Add(item); };
            if (citytId == 558) { item.StateId = 22; item.Name = "Żukowo"; _list.Add(item); };
            if (citytId == 559) { item.StateId = 22; item.Name = "Kościerzyna"; _list.Add(item); };
            if (citytId == 560) { item.StateId = 22; item.Name = "Kwidzyn"; _list.Add(item); };
            if (citytId == 561) { item.StateId = 22; item.Name = "Prabuty"; _list.Add(item); };
            if (citytId == 562) { item.StateId = 22; item.Name = "Lębork"; _list.Add(item); };
            if (citytId == 563) { item.StateId = 22; item.Name = "Łeba"; _list.Add(item); };
            if (citytId == 564) { item.StateId = 22; item.Name = "Malbork"; _list.Add(item); };
            if (citytId == 565) { item.StateId = 22; item.Name = "Nowy Staw"; _list.Add(item); };
            if (citytId == 566) { item.StateId = 22; item.Name = "Krynica Morska"; _list.Add(item); };
            if (citytId == 567) { item.StateId = 22; item.Name = "Nowy Dwór Gdański"; _list.Add(item); };
            if (citytId == 568) { item.StateId = 22; item.Name = "Hel"; _list.Add(item); };
            if (citytId == 569) { item.StateId = 22; item.Name = "Jastarnia"; _list.Add(item); };
            if (citytId == 570) { item.StateId = 22; item.Name = "Puck"; _list.Add(item); };
            if (citytId == 571) { item.StateId = 22; item.Name = "Władysławowo"; _list.Add(item); };
            if (citytId == 572) { item.StateId = 22; item.Name = "Ustka"; _list.Add(item); };
            if (citytId == 573) { item.StateId = 22; item.Name = "Kępice"; _list.Add(item); };
            if (citytId == 574) { item.StateId = 22; item.Name = "Czarna Woda"; _list.Add(item); };
            if (citytId == 575) { item.StateId = 22; item.Name = "Skórcz"; _list.Add(item); };
            if (citytId == 576) { item.StateId = 22; item.Name = "Starogard Gdański"; _list.Add(item); };
            if (citytId == 577) { item.StateId = 22; item.Name = "Skarszewy"; _list.Add(item); };
            if (citytId == 578) { item.StateId = 22; item.Name = "Tczew"; _list.Add(item); };
            if (citytId == 579) { item.StateId = 22; item.Name = "Gniew"; _list.Add(item); };
            if (citytId == 580) { item.StateId = 22; item.Name = "Pelplin"; _list.Add(item); };
            if (citytId == 581) { item.StateId = 22; item.Name = "Reda"; _list.Add(item); };
            if (citytId == 582) { item.StateId = 22; item.Name = "Rumia"; _list.Add(item); };
            if (citytId == 583) { item.StateId = 22; item.Name = "Wejherowo"; _list.Add(item); };
            if (citytId == 584) { item.StateId = 22; item.Name = "Dzierzgoń"; _list.Add(item); };
            if (citytId == 585) { item.StateId = 22; item.Name = "Sztum"; _list.Add(item); };
            if (citytId == 586) { item.StateId = 22; item.Name = "Gdańsk"; _list.Add(item); };
            if (citytId == 587) { item.StateId = 22; item.Name = "Gdynia"; _list.Add(item); };
            if (citytId == 588) { item.StateId = 22; item.Name = "Słupsk"; _list.Add(item); };
            if (citytId == 589) { item.StateId = 22; item.Name = "Sopot"; _list.Add(item); };
            if (citytId == 590) { item.StateId = 24; item.Name = "Będzin"; _list.Add(item); };
            if (citytId == 591) { item.StateId = 24; item.Name = "Czeladź"; _list.Add(item); };
            if (citytId == 592) { item.StateId = 24; item.Name = "Wojkowice"; _list.Add(item); };
            if (citytId == 593) { item.StateId = 24; item.Name = "Siewierz"; _list.Add(item); };
            if (citytId == 594) { item.StateId = 24; item.Name = "Sławków"; _list.Add(item); };
            if (citytId == 595) { item.StateId = 24; item.Name = "Szczyrk"; _list.Add(item); };
            if (citytId == 596) { item.StateId = 24; item.Name = "Czechowice-Dziedzice"; _list.Add(item); };
            if (citytId == 597) { item.StateId = 24; item.Name = "Wilamowice"; _list.Add(item); };
            if (citytId == 598) { item.StateId = 24; item.Name = "Cieszyn"; _list.Add(item); };
            if (citytId == 599) { item.StateId = 24; item.Name = "Ustroń"; _list.Add(item); };
            if (citytId == 600) { item.StateId = 24; item.Name = "Wisła"; _list.Add(item); };
            if (citytId == 601) { item.StateId = 24; item.Name = "Skoczów"; _list.Add(item); };
            if (citytId == 602) { item.StateId = 24; item.Name = "Strumień"; _list.Add(item); };
            if (citytId == 603) { item.StateId = 24; item.Name = "Blachownia"; _list.Add(item); };
            if (citytId == 604) { item.StateId = 24; item.Name = "Koniecpol"; _list.Add(item); };
            if (citytId == 605) { item.StateId = 24; item.Name = "Knurów"; _list.Add(item); };
            if (citytId == 606) { item.StateId = 24; item.Name = "Pyskowice"; _list.Add(item); };
            if (citytId == 607) { item.StateId = 24; item.Name = "Sośnicowice"; _list.Add(item); };
            if (citytId == 608) { item.StateId = 24; item.Name = "Toszek"; _list.Add(item); };
            if (citytId == 609) { item.StateId = 24; item.Name = "Kłobuck"; _list.Add(item); };
            if (citytId == 610) { item.StateId = 24; item.Name = "Krzepice"; _list.Add(item); };
            if (citytId == 611) { item.StateId = 24; item.Name = "Lubliniec"; _list.Add(item); };
            if (citytId == 612) { item.StateId = 24; item.Name = "Woźniki"; _list.Add(item); };
            if (citytId == 613) { item.StateId = 24; item.Name = "Łaziska Górne"; _list.Add(item); };
            if (citytId == 614) { item.StateId = 24; item.Name = "Mikołów"; _list.Add(item); };
            if (citytId == 615) { item.StateId = 24; item.Name = "Orzesze"; _list.Add(item); };
            if (citytId == 616) { item.StateId = 24; item.Name = "Myszków"; _list.Add(item); };
            if (citytId == 617) { item.StateId = 24; item.Name = "Koziegłowy"; _list.Add(item); };
            if (citytId == 618) { item.StateId = 24; item.Name = "Żarki"; _list.Add(item); };
            if (citytId == 619) { item.StateId = 24; item.Name = "Pszczyna"; _list.Add(item); };
            if (citytId == 620) { item.StateId = 24; item.Name = "Racibórz"; _list.Add(item); };
            if (citytId == 621) { item.StateId = 24; item.Name = "Krzanowice"; _list.Add(item); };
            if (citytId == 622) { item.StateId = 24; item.Name = "Kuźnia Raciborska"; _list.Add(item); };
            if (citytId == 623) { item.StateId = 24; item.Name = "Czerwionka-Leszczyny"; _list.Add(item); };
            if (citytId == 624) { item.StateId = 24; item.Name = "Kalety"; _list.Add(item); };
            if (citytId == 625) { item.StateId = 24; item.Name = "Miasteczko Śląskie"; _list.Add(item); };
            if (citytId == 626) { item.StateId = 24; item.Name = "Radzionków"; _list.Add(item); };
            if (citytId == 627) { item.StateId = 24; item.Name = "Tarnowskie Góry"; _list.Add(item); };
            if (citytId == 628) { item.StateId = 24; item.Name = "Bieruń"; _list.Add(item); };
            if (citytId == 629) { item.StateId = 24; item.Name = "Imielin"; _list.Add(item); };
            if (citytId == 630) { item.StateId = 24; item.Name = "Lędziny"; _list.Add(item); };
            if (citytId == 631) { item.StateId = 24; item.Name = "Pszów"; _list.Add(item); };
            if (citytId == 632) { item.StateId = 24; item.Name = "Radlin"; _list.Add(item); };
            if (citytId == 633) { item.StateId = 24; item.Name = "Rydułtowy"; _list.Add(item); };
            if (citytId == 634) { item.StateId = 24; item.Name = "Wodzisław Śląski"; _list.Add(item); };
            if (citytId == 635) { item.StateId = 24; item.Name = "Poręba"; _list.Add(item); };
            if (citytId == 636) { item.StateId = 24; item.Name = "Zawiercie"; _list.Add(item); };
            if (citytId == 637) { item.StateId = 24; item.Name = "Łazy"; _list.Add(item); };
            if (citytId == 638) { item.StateId = 24; item.Name = "Ogrodzieniec"; _list.Add(item); };
            if (citytId == 639) { item.StateId = 24; item.Name = "Pilica"; _list.Add(item); };
            if (citytId == 640) { item.StateId = 24; item.Name = "Szczekociny"; _list.Add(item); };
            if (citytId == 641) { item.StateId = 24; item.Name = "Żywiec"; _list.Add(item); };
            if (citytId == 642) { item.StateId = 24; item.Name = "Bielsko-Biała"; _list.Add(item); };
            if (citytId == 643) { item.StateId = 24; item.Name = "Bytom"; _list.Add(item); };
            if (citytId == 644) { item.StateId = 24; item.Name = "Chorzów"; _list.Add(item); };
            if (citytId == 645) { item.StateId = 24; item.Name = "Częstochowa"; _list.Add(item); };
            if (citytId == 646) { item.StateId = 24; item.Name = "Dąbrowa Górnicza"; _list.Add(item); };
            if (citytId == 647) { item.StateId = 24; item.Name = "Gliwice"; _list.Add(item); };
            if (citytId == 648) { item.StateId = 24; item.Name = "Jastrzębie-Zdrój"; _list.Add(item); };
            if (citytId == 649) { item.StateId = 24; item.Name = "Jaworzno"; _list.Add(item); };
            if (citytId == 650) { item.StateId = 24; item.Name = "Katowice"; _list.Add(item); };
            if (citytId == 651) { item.StateId = 24; item.Name = "Mysłowice"; _list.Add(item); };
            if (citytId == 652) { item.StateId = 24; item.Name = "Piekary Śląskie"; _list.Add(item); };
            if (citytId == 653) { item.StateId = 24; item.Name = "Ruda Śląska"; _list.Add(item); };
            if (citytId == 654) { item.StateId = 24; item.Name = "Rybnik"; _list.Add(item); };
            if (citytId == 655) { item.StateId = 24; item.Name = "Siemianowice Śląskie"; _list.Add(item); };
            if (citytId == 656) { item.StateId = 24; item.Name = "Sosnowiec"; _list.Add(item); };
            if (citytId == 657) { item.StateId = 24; item.Name = "Świętochłowice"; _list.Add(item); };
            if (citytId == 658) { item.StateId = 24; item.Name = "Tychy"; _list.Add(item); };
            if (citytId == 659) { item.StateId = 24; item.Name = "Zabrze"; _list.Add(item); };
            if (citytId == 660) { item.StateId = 24; item.Name = "Żory"; _list.Add(item); };
            if (citytId == 661) { item.StateId = 26; item.Name = "Busko-Zdrój"; _list.Add(item); };
            if (citytId == 662) { item.StateId = 26; item.Name = "Stopnica"; _list.Add(item); };
            if (citytId == 663) { item.StateId = 26; item.Name = "Jędrzejów"; _list.Add(item); };
            if (citytId == 664) { item.StateId = 26; item.Name = "Małogoszcz"; _list.Add(item); };
            if (citytId == 665) { item.StateId = 26; item.Name = "Sędziszów"; _list.Add(item); };
            if (citytId == 666) { item.StateId = 26; item.Name = "Kazimierza Wielka"; _list.Add(item); };
            if (citytId == 667) { item.StateId = 26; item.Name = "Skalbmierz"; _list.Add(item); };
            if (citytId == 668) { item.StateId = 26; item.Name = "Bodzentyn"; _list.Add(item); };
            if (citytId == 669) { item.StateId = 26; item.Name = "Chęciny"; _list.Add(item); };
            if (citytId == 670) { item.StateId = 26; item.Name = "Chmielnik"; _list.Add(item); };
            if (citytId == 671) { item.StateId = 26; item.Name = "Daleszyce"; _list.Add(item); };
            if (citytId == 672) { item.StateId = 26; item.Name = "Końskie"; _list.Add(item); };
            if (citytId == 673) { item.StateId = 26; item.Name = "Stąporków"; _list.Add(item); };
            if (citytId == 674) { item.StateId = 26; item.Name = "Opatów"; _list.Add(item); };
            if (citytId == 675) { item.StateId = 26; item.Name = "Ożarów"; _list.Add(item); };
            if (citytId == 676) { item.StateId = 26; item.Name = "Ostrowiec Świętokrzyski"; _list.Add(item); };
            if (citytId == 677) { item.StateId = 26; item.Name = "Ćmielów"; _list.Add(item); };
            if (citytId == 678) { item.StateId = 26; item.Name = "Kunów"; _list.Add(item); };
            if (citytId == 679) { item.StateId = 26; item.Name = "Działoszyce"; _list.Add(item); };
            if (citytId == 680) { item.StateId = 26; item.Name = "Pińczów"; _list.Add(item); };
            if (citytId == 681) { item.StateId = 26; item.Name = "Sandomierz"; _list.Add(item); };
            if (citytId == 682) { item.StateId = 26; item.Name = "Koprzywnica"; _list.Add(item); };
            if (citytId == 683) { item.StateId = 26; item.Name = "Zawichost"; _list.Add(item); };
            if (citytId == 684) { item.StateId = 26; item.Name = "Skarżysko-Kamienna"; _list.Add(item); };
            if (citytId == 685) { item.StateId = 26; item.Name = "Suchedniów"; _list.Add(item); };
            if (citytId == 686) { item.StateId = 26; item.Name = "Starachowice"; _list.Add(item); };
            if (citytId == 687) { item.StateId = 26; item.Name = "Wąchock"; _list.Add(item); };
            if (citytId == 688) { item.StateId = 26; item.Name = "Osiek"; _list.Add(item); };
            if (citytId == 689) { item.StateId = 26; item.Name = "Połaniec"; _list.Add(item); };
            if (citytId == 690) { item.StateId = 26; item.Name = "Staszów"; _list.Add(item); };
            if (citytId == 691) { item.StateId = 26; item.Name = "Włoszczowa"; _list.Add(item); };
            if (citytId == 692) { item.StateId = 26; item.Name = "Kielce"; _list.Add(item); };
            if (citytId == 693) { item.StateId = 28; item.Name = "Bartoszyce"; _list.Add(item); }; //błąd
            if (citytId == 694) { item.StateId = 28; item.Name = "Górowo Iławeckie"; _list.Add(item); };//błąd
            if (citytId == 695) { item.StateId = 28; item.Name = "Bisztynek"; _list.Add(item); };
            if (citytId == 696) { item.StateId = 28; item.Name = "Sępopol"; _list.Add(item); };
            if (citytId == 697) { item.StateId = 28; item.Name = "Braniewo"; _list.Add(item); };
            if (citytId == 698) { item.StateId = 28; item.Name = "Frombork"; _list.Add(item); };
            if (citytId == 699) { item.StateId = 28; item.Name = "Pieniężno"; _list.Add(item); };
            if (citytId == 700) { item.StateId = 28; item.Name = "Działdowo"; _list.Add(item); }; //start po błędzie
            if (citytId == 701) { item.StateId = 28; item.Name = "Lidzbark"; _list.Add(item); };
            if (citytId == 702) { item.StateId = 28; item.Name = "Młynary"; _list.Add(item); };
            if (citytId == 703) { item.StateId = 28; item.Name = "Pasłęk"; _list.Add(item); };
            if (citytId == 704) { item.StateId = 28; item.Name = "Tolkmicko"; _list.Add(item); };
            if (citytId == 705) { item.StateId = 28; item.Name = "Ełk"; _list.Add(item); };//błąd
            if (citytId == 706) { item.StateId = 28; item.Name = "Giżycko"; _list.Add(item); };//błąd
            if (citytId == 707) { item.StateId = 28; item.Name = "Ryn"; _list.Add(item); };
            if (citytId == 708) { item.StateId = 28; item.Name = "Iława"; _list.Add(item); };
            if (citytId == 709) { item.StateId = 28; item.Name = "Lubawa"; _list.Add(item); };
            if (citytId == 710) { item.StateId = 28; item.Name = "Kisielice"; _list.Add(item); };
            if (citytId == 711) { item.StateId = 28; item.Name = "Susz"; _list.Add(item); };
            if (citytId == 712) { item.StateId = 28; item.Name = "Zalewo"; _list.Add(item); };
            if (citytId == 713) { item.StateId = 28; item.Name = "Kętrzyn"; _list.Add(item); };
            if (citytId == 714) { item.StateId = 28; item.Name = "Korsze"; _list.Add(item); };//błąd
            if (citytId == 715) { item.StateId = 28; item.Name = "Reszel"; _list.Add(item); };
            if (citytId == 716) { item.StateId = 28; item.Name = "Lidzbark Warmiński"; _list.Add(item); };
            if (citytId == 717) { item.StateId = 28; item.Name = "Orneta"; _list.Add(item); };
            if (citytId == 718) { item.StateId = 28; item.Name = "Mrągowo"; _list.Add(item); };
            if (citytId == 719) { item.StateId = 28; item.Name = "Mikołajki"; _list.Add(item); };
            if (citytId == 720) { item.StateId = 28; item.Name = "Nidzica"; _list.Add(item); };
            if (citytId == 721) { item.StateId = 28; item.Name = "Nowe Miasto Lubawskie"; _list.Add(item); };
            if (citytId == 722) { item.StateId = 28; item.Name = "Olecko"; _list.Add(item); };//błąd
            if (citytId == 723) { item.StateId = 28; item.Name = "Barczewo"; _list.Add(item); };
            if (citytId == 724) { item.StateId = 28; item.Name = "Biskupiec"; _list.Add(item); };
            if (citytId == 725) { item.StateId = 28; item.Name = "Dobre Miasto"; _list.Add(item); };
            if (citytId == 726) { item.StateId = 28; item.Name = "Jeziorany"; _list.Add(item); };
            if (citytId == 727) { item.StateId = 28; item.Name = "Olsztynek"; _list.Add(item); };
            if (citytId == 728) { item.StateId = 28; item.Name = "Ostróda"; _list.Add(item); };
            if (citytId == 729) { item.StateId = 28; item.Name = "Miłakowo"; _list.Add(item); };
            if (citytId == 730) { item.StateId = 28; item.Name = "Miłomłyn"; _list.Add(item); };
            if (citytId == 731) { item.StateId = 28; item.Name = "Morąg"; _list.Add(item); };
            if (citytId == 732) { item.StateId = 28; item.Name = "Biała Piska"; _list.Add(item); };//błąd
            if (citytId == 733) { item.StateId = 28; item.Name = "Orzysz"; _list.Add(item); };
            if (citytId == 734) { item.StateId = 28; item.Name = "Pisz"; _list.Add(item); };
            if (citytId == 735) { item.StateId = 28; item.Name = "Ruciane-Nida"; _list.Add(item); };
            if (citytId == 736) { item.StateId = 28; item.Name = "Szczytno"; _list.Add(item); };
            if (citytId == 737) { item.StateId = 28; item.Name = "Pasym"; _list.Add(item); };
            if (citytId == 738) { item.StateId = 28; item.Name = "Gołdap"; _list.Add(item); };
            if (citytId == 739) { item.StateId = 28; item.Name = "Węgorzewo"; _list.Add(item); }; ////błąd
            if (citytId == 740) { item.StateId = 28; item.Name = "Elbląg"; _list.Add(item); };
            if (citytId == 741) { item.StateId = 28; item.Name = "Olsztyn"; _list.Add(item); };
            if (citytId == 742) { item.StateId = 30; item.Name = "Chodzież"; _list.Add(item); };
            if (citytId == 743) { item.StateId = 30; item.Name = "Margonin"; _list.Add(item); };
            if (citytId == 744) { item.StateId = 30; item.Name = "Szamocin"; _list.Add(item); };
            if (citytId == 745) { item.StateId = 30; item.Name = "Czarnków"; _list.Add(item); };
            if (citytId == 746) { item.StateId = 30; item.Name = "Krzyż Wielkopolski"; _list.Add(item); };
            if (citytId == 747) { item.StateId = 30; item.Name = "Trzcianka"; _list.Add(item); };
            if (citytId == 748) { item.StateId = 30; item.Name = "Wieleń"; _list.Add(item); };
            if (citytId == 749) { item.StateId = 30; item.Name = "Gniezno"; _list.Add(item); };
            if (citytId == 750) { item.StateId = 30; item.Name = "Czerniejewo"; _list.Add(item); };
            if (citytId == 751) { item.StateId = 30; item.Name = "Kłecko"; _list.Add(item); };
            if (citytId == 752) { item.StateId = 30; item.Name = "Trzemeszno"; _list.Add(item); };
            if (citytId == 753) { item.StateId = 30; item.Name = "Witkowo"; _list.Add(item); };
            if (citytId == 754) { item.StateId = 30; item.Name = "Borek Wielkopolski"; _list.Add(item); };
            if (citytId == 755) { item.StateId = 30; item.Name = "Gostyń"; _list.Add(item); };
            if (citytId == 756) { item.StateId = 30; item.Name = "Krobia"; _list.Add(item); };
            if (citytId == 757) { item.StateId = 30; item.Name = "Pogorzela"; _list.Add(item); };
            if (citytId == 758) { item.StateId = 30; item.Name = "Poniec"; _list.Add(item); };
            if (citytId == 759) { item.StateId = 30; item.Name = "Grodzisk Wielkopolski"; _list.Add(item); };
            if (citytId == 760) { item.StateId = 30; item.Name = "Rakoniewice"; _list.Add(item); };
            if (citytId == 761) { item.StateId = 30; item.Name = "Wielichowo"; _list.Add(item); };
            if (citytId == 762) { item.StateId = 30; item.Name = "Jaraczewo"; _list.Add(item); };
            if (citytId == 763) { item.StateId = 30; item.Name = "Jarocin"; _list.Add(item); };
            if (citytId == 764) { item.StateId = 30; item.Name = "Żerków"; _list.Add(item); };
            if (citytId == 765) { item.StateId = 30; item.Name = "Stawiszyn"; _list.Add(item); };
            if (citytId == 766) { item.StateId = 30; item.Name = "Kępno"; _list.Add(item); };
            if (citytId == 767) { item.StateId = 30; item.Name = "Koło"; _list.Add(item); };
            if (citytId == 768) { item.StateId = 30; item.Name = "Dąbie"; _list.Add(item); };
            if (citytId == 769) { item.StateId = 30; item.Name = "Kłodawa"; _list.Add(item); };
            if (citytId == 770) { item.StateId = 30; item.Name = "Przedecz"; _list.Add(item); };
            if (citytId == 771) { item.StateId = 30; item.Name = "Golina"; _list.Add(item); };
            if (citytId == 772) { item.StateId = 30; item.Name = "Kleczew"; _list.Add(item); };
            if (citytId == 773) { item.StateId = 30; item.Name = "Rychwał"; _list.Add(item); };
            if (citytId == 774) { item.StateId = 30; item.Name = "Sompolno"; _list.Add(item); };
            if (citytId == 775) { item.StateId = 30; item.Name = "Ślesin"; _list.Add(item); };
            if (citytId == 776) { item.StateId = 30; item.Name = "Kościan"; _list.Add(item); };
            if (citytId == 777) { item.StateId = 30; item.Name = "Czempiń"; _list.Add(item); };
            if (citytId == 778) { item.StateId = 30; item.Name = "Krzywiń"; _list.Add(item); };
            if (citytId == 779) { item.StateId = 30; item.Name = "Śmigiel"; _list.Add(item); };
            if (citytId == 780) { item.StateId = 30; item.Name = "Sulmierzyce"; _list.Add(item); };
            if (citytId == 781) { item.StateId = 30; item.Name = "Kobylin"; _list.Add(item); };
            if (citytId == 782) { item.StateId = 30; item.Name = "Koźmin Wielkopolski"; _list.Add(item); };
            if (citytId == 783) { item.StateId = 30; item.Name = "Krotoszyn"; _list.Add(item); };
            if (citytId == 784) { item.StateId = 30; item.Name = "Zduny"; _list.Add(item); };
            if (citytId == 785) { item.StateId = 30; item.Name = "Osieczna"; _list.Add(item); };
            if (citytId == 786) { item.StateId = 30; item.Name = "Rydzyna"; _list.Add(item); };
            if (citytId == 787) { item.StateId = 30; item.Name = "Międzychód"; _list.Add(item); };
            if (citytId == 788) { item.StateId = 30; item.Name = "Sieraków"; _list.Add(item); };
            if (citytId == 789) { item.StateId = 30; item.Name = "Lwówek"; _list.Add(item); };
            if (citytId == 790) { item.StateId = 30; item.Name = "Nowy Tomyśl"; _list.Add(item); };
            if (citytId == 791) { item.StateId = 30; item.Name = "Opalenica"; _list.Add(item); };
            if (citytId == 792) { item.StateId = 30; item.Name = "Zbąszyń"; _list.Add(item); };
            if (citytId == 793) { item.StateId = 30; item.Name = "Oborniki"; _list.Add(item); };
            if (citytId == 794) { item.StateId = 30; item.Name = "Rogoźno"; _list.Add(item); };
            if (citytId == 795) { item.StateId = 30; item.Name = "Ostrów Wielkopolski"; _list.Add(item); };
            if (citytId == 796) { item.StateId = 30; item.Name = "Nowe Skalmierzyce"; _list.Add(item); };
            if (citytId == 797) { item.StateId = 30; item.Name = "Odolanów"; _list.Add(item); };
            if (citytId == 798) { item.StateId = 30; item.Name = "Raszków"; _list.Add(item); };
            if (citytId == 799) { item.StateId = 30; item.Name = "Grabów nad Prosną"; _list.Add(item); };
            if (citytId == 800) { item.StateId = 30; item.Name = "Mikstat"; _list.Add(item); };
            if (citytId == 801) { item.StateId = 30; item.Name = "Ostrzeszów"; _list.Add(item); };
            if (citytId == 802) { item.StateId = 30; item.Name = "Piła"; _list.Add(item); };
            if (citytId == 803) { item.StateId = 30; item.Name = "Łobżenica"; _list.Add(item); };
            if (citytId == 804) { item.StateId = 30; item.Name = "Ujście"; _list.Add(item); };
            if (citytId == 805) { item.StateId = 30; item.Name = "Wyrzysk"; _list.Add(item); };
            if (citytId == 806) { item.StateId = 30; item.Name = "Wysoka"; _list.Add(item); };
            if (citytId == 807) { item.StateId = 30; item.Name = "Chocz"; _list.Add(item); };
            if (citytId == 808) { item.StateId = 30; item.Name = "Dobrzyca"; _list.Add(item); };
            if (citytId == 809) { item.StateId = 30; item.Name = "Pleszew"; _list.Add(item); };
            if (citytId == 810) { item.StateId = 30; item.Name = "Luboń"; _list.Add(item); };
            if (citytId == 811) { item.StateId = 30; item.Name = "Puszczykowo"; _list.Add(item); };
            if (citytId == 812) { item.StateId = 30; item.Name = "Buk"; _list.Add(item); };
            if (citytId == 813) { item.StateId = 30; item.Name = "Kostrzyn"; _list.Add(item); };
            if (citytId == 814) { item.StateId = 30; item.Name = "Kórnik"; _list.Add(item); };
            if (citytId == 815) { item.StateId = 30; item.Name = "Mosina"; _list.Add(item); };
            if (citytId == 816) { item.StateId = 30; item.Name = "Murowana Goślina"; _list.Add(item); };
            if (citytId == 817) { item.StateId = 30; item.Name = "Pobiedziska"; _list.Add(item); };
            if (citytId == 818) { item.StateId = 30; item.Name = "Stęszew"; _list.Add(item); };
            if (citytId == 819) { item.StateId = 30; item.Name = "Swarzędz"; _list.Add(item); };
            if (citytId == 820) { item.StateId = 30; item.Name = "Bojanowo"; _list.Add(item); };
            if (citytId == 821) { item.StateId = 30; item.Name = "Jutrosin"; _list.Add(item); };
            if (citytId == 822) { item.StateId = 30; item.Name = "Miejska Górka"; _list.Add(item); };
            if (citytId == 823) { item.StateId = 30; item.Name = "Rawicz"; _list.Add(item); };
            if (citytId == 824) { item.StateId = 30; item.Name = "Słupca"; _list.Add(item); };
            if (citytId == 825) { item.StateId = 30; item.Name = "Zagórów"; _list.Add(item); };
            if (citytId == 826) { item.StateId = 30; item.Name = "Obrzycko"; _list.Add(item); };
            if (citytId == 827) { item.StateId = 30; item.Name = "Ostroróg"; _list.Add(item); };
            if (citytId == 828) { item.StateId = 30; item.Name = "Pniewy"; _list.Add(item); };
            if (citytId == 829) { item.StateId = 30; item.Name = "Szamotuły"; _list.Add(item); };
            if (citytId == 830) { item.StateId = 30; item.Name = "Wronki"; _list.Add(item); };
            if (citytId == 831) { item.StateId = 30; item.Name = "Środa Wielkopolska"; _list.Add(item); };
            if (citytId == 832) { item.StateId = 30; item.Name = "Dolsk"; _list.Add(item); };
            if (citytId == 833) { item.StateId = 30; item.Name = "Książ Wielkopolski"; _list.Add(item); };
            if (citytId == 834) { item.StateId = 30; item.Name = "Śrem"; _list.Add(item); };
            if (citytId == 835) { item.StateId = 30; item.Name = "Turek"; _list.Add(item); };
            if (citytId == 836) { item.StateId = 30; item.Name = "Dobra"; _list.Add(item); };
            if (citytId == 837) { item.StateId = 30; item.Name = "Tuliszków"; _list.Add(item); };
            if (citytId == 838) { item.StateId = 30; item.Name = "Wągrowiec"; _list.Add(item); };
            if (citytId == 839) { item.StateId = 30; item.Name = "Gołańcz"; _list.Add(item); };
            if (citytId == 840) { item.StateId = 30; item.Name = "Skoki"; _list.Add(item); };
            if (citytId == 841) { item.StateId = 30; item.Name = "Wolsztyn"; _list.Add(item); };
            if (citytId == 842) { item.StateId = 30; item.Name = "Miłosław"; _list.Add(item); };
            if (citytId == 843) { item.StateId = 30; item.Name = "Nekla"; _list.Add(item); };
            if (citytId == 844) { item.StateId = 30; item.Name = "Pyzdry"; _list.Add(item); };
            if (citytId == 845) { item.StateId = 30; item.Name = "Września"; _list.Add(item); };
            if (citytId == 846) { item.StateId = 30; item.Name = "Złotów"; _list.Add(item); };
            if (citytId == 847) { item.StateId = 30; item.Name = "Jastrowie"; _list.Add(item); };
            if (citytId == 848) { item.StateId = 30; item.Name = "Krajenka"; _list.Add(item); };
            if (citytId == 849) { item.StateId = 30; item.Name = "Okonek"; _list.Add(item); };
            if (citytId == 850) { item.StateId = 30; item.Name = "Kalisz"; _list.Add(item); };
            if (citytId == 851) { item.StateId = 30; item.Name = "Konin"; _list.Add(item); };
            if (citytId == 852) { item.StateId = 30; item.Name = "Leszno"; _list.Add(item); };
            if (citytId == 853) { item.StateId = 30; item.Name = "Poznań"; _list.Add(item); };
            if (citytId == 854) { item.StateId = 32; item.Name = "Białogard"; _list.Add(item); };
            if (citytId == 855) { item.StateId = 32; item.Name = "Karlino"; _list.Add(item); };
            if (citytId == 856) { item.StateId = 32; item.Name = "Tychowo"; _list.Add(item); };
            if (citytId == 857) { item.StateId = 32; item.Name = "Choszczno"; _list.Add(item); };
            if (citytId == 858) { item.StateId = 32; item.Name = "Drawno"; _list.Add(item); };
            if (citytId == 859) { item.StateId = 32; item.Name = "Pełczyce"; _list.Add(item); };
            if (citytId == 860) { item.StateId = 32; item.Name = "Recz"; _list.Add(item); };
            if (citytId == 861) { item.StateId = 32; item.Name = "Czaplinek"; _list.Add(item); };
            if (citytId == 862) { item.StateId = 32; item.Name = "Drawsko Pomorskie"; _list.Add(item); };
            if (citytId == 863) { item.StateId = 32; item.Name = "Kalisz Pomorski"; _list.Add(item); };
            if (citytId == 864) { item.StateId = 32; item.Name = "Złocieniec"; _list.Add(item); };
            if (citytId == 865) { item.StateId = 32; item.Name = "Goleniów"; _list.Add(item); };
            if (citytId == 866) { item.StateId = 32; item.Name = "Maszewo"; _list.Add(item); };
            if (citytId == 867) { item.StateId = 32; item.Name = "Nowogard"; _list.Add(item); };
            if (citytId == 868) { item.StateId = 32; item.Name = "Stepnica"; _list.Add(item); };
            if (citytId == 869) { item.StateId = 32; item.Name = "Gryfice"; _list.Add(item); };
            if (citytId == 870) { item.StateId = 32; item.Name = "Płoty"; _list.Add(item); };
            if (citytId == 871) { item.StateId = 32; item.Name = "Trzebiatów"; _list.Add(item); };
            if (citytId == 872) { item.StateId = 32; item.Name = "Cedynia"; _list.Add(item); };
            if (citytId == 873) { item.StateId = 32; item.Name = "Chojna"; _list.Add(item); };
            if (citytId == 874) { item.StateId = 32; item.Name = "Gryfino"; _list.Add(item); };
            if (citytId == 875) { item.StateId = 32; item.Name = "Mieszkowice"; _list.Add(item); };
            if (citytId == 876) { item.StateId = 32; item.Name = "Moryń"; _list.Add(item); };
            if (citytId == 877) { item.StateId = 32; item.Name = "Trzcińsko-Zdrój"; _list.Add(item); };
            if (citytId == 878) { item.StateId = 32; item.Name = "Dziwnów"; _list.Add(item); };
            if (citytId == 879) { item.StateId = 32; item.Name = "Golczewo"; _list.Add(item); };
            if (citytId == 880) { item.StateId = 32; item.Name = "Kamień Pomorski"; _list.Add(item); };
            if (citytId == 881) { item.StateId = 32; item.Name = "Międzyzdroje"; _list.Add(item); };
            if (citytId == 882) { item.StateId = 32; item.Name = "Wolin"; _list.Add(item); };
            if (citytId == 883) { item.StateId = 32; item.Name = "Kołobrzeg"; _list.Add(item); };
            if (citytId == 884) { item.StateId = 32; item.Name = "Gościno"; _list.Add(item); };
            if (citytId == 885) { item.StateId = 32; item.Name = "Bobolice"; _list.Add(item); };
            if (citytId == 886) { item.StateId = 32; item.Name = "Polanów"; _list.Add(item); };
            if (citytId == 887) { item.StateId = 32; item.Name = "Sianów"; _list.Add(item); };
            if (citytId == 888) { item.StateId = 32; item.Name = "Barlinek"; _list.Add(item); };
            if (citytId == 889) { item.StateId = 32; item.Name = "Dębno"; _list.Add(item); };
            if (citytId == 890) { item.StateId = 32; item.Name = "Myślibórz"; _list.Add(item); };
            if (citytId == 891) { item.StateId = 32; item.Name = "Nowe Warpno"; _list.Add(item); };
            if (citytId == 892) { item.StateId = 32; item.Name = "Police"; _list.Add(item); };
            if (citytId == 893) { item.StateId = 32; item.Name = "Lipiany"; _list.Add(item); };
            if (citytId == 894) { item.StateId = 32; item.Name = "Pyrzyce"; _list.Add(item); };
            if (citytId == 895) { item.StateId = 32; item.Name = "Darłowo"; _list.Add(item); };
            if (citytId == 896) { item.StateId = 32; item.Name = "Sławno"; _list.Add(item); };
            if (citytId == 897) { item.StateId = 32; item.Name = "Stargard"; _list.Add(item); };
            if (citytId == 898) { item.StateId = 32; item.Name = "Chociwel"; _list.Add(item); };
            if (citytId == 899) { item.StateId = 32; item.Name = "Dobrzany"; _list.Add(item); };
            if (citytId == 900) { item.StateId = 32; item.Name = "Ińsko"; _list.Add(item); };
            if (citytId == 901) { item.StateId = 32; item.Name = "Suchań"; _list.Add(item); };
            if (citytId == 902) { item.StateId = 32; item.Name = "Szczecinek"; _list.Add(item); };
            if (citytId == 903) { item.StateId = 32; item.Name = "Barwice"; _list.Add(item); };
            if (citytId == 904) { item.StateId = 32; item.Name = "Biały Bór"; _list.Add(item); };
            if (citytId == 905) { item.StateId = 32; item.Name = "Borne Sulinowo"; _list.Add(item); };
            if (citytId == 906) { item.StateId = 32; item.Name = "Świdwin"; _list.Add(item); };
            if (citytId == 907) { item.StateId = 32; item.Name = "Połczyn-Zdrój"; _list.Add(item); };
            if (citytId == 908) { item.StateId = 32; item.Name = "Wałcz"; _list.Add(item); };
            if (citytId == 909) { item.StateId = 32; item.Name = "Człopa"; _list.Add(item); };
            if (citytId == 910) { item.StateId = 32; item.Name = "Mirosławiec"; _list.Add(item); };
            if (citytId == 911) { item.StateId = 32; item.Name = "Tuczno"; _list.Add(item); };
            if (citytId == 912) { item.StateId = 32; item.Name = "Dobra"; _list.Add(item); };
            if (citytId == 913) { item.StateId = 32; item.Name = "Łobez"; _list.Add(item); };
            if (citytId == 914) { item.StateId = 32; item.Name = "Resko"; _list.Add(item); };
            if (citytId == 915) { item.StateId = 32; item.Name = "Węgorzyno"; _list.Add(item); };
            if (citytId == 916) { item.StateId = 32; item.Name = "Koszalin"; _list.Add(item); };
            if (citytId == 917) { item.StateId = 32; item.Name = "Szczecin"; _list.Add(item); };
            if (citytId == 918) { item.StateId = 32; item.Name = "Świnoujście"; _list.Add(item); };


            return _list;
        }

    }
}