HttpClient httpClient = new();
var response = await httpClient.GetAsync("http://localhost:5133/api/values");

if(response.IsSuccessStatusCode){
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}