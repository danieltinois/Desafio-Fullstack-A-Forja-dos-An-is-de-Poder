using ForjaDosAneisFrontend.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ForjaDosAneisFrontend.Services
{
  public class AnelService : IAnelService
  {
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:5226/api/anéis"; // URL da sua API

    public AnelService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    // Obter todos os anéis
    public async Task<List<Anel>> GetAnéisAsync()
    {
      var response = await _httpClient.GetAsync(_baseUrl);
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadFromJsonAsync<List<Anel>>();
    }

    // Criar um novo anel
    public async Task CreateAnelAsync(Anel anel)
    {
      var response = await _httpClient.PostAsJsonAsync(_baseUrl, anel);
      response.EnsureSuccessStatusCode();
    }

    // Atualizar um anel existente
    public async Task UpdateAnelAsync(int id, Anel anel)
    {
      var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", anel);
      response.EnsureSuccessStatusCode();

      if (!response.IsSuccessStatusCode)
      {
        var errorContent = await response.Content.ReadAsStringAsync();
        throw new Exception($"Erro ao atualizar anel: {response.StatusCode} - {errorContent}");
      }
    }

    // Excluir um anel
    public async Task DeleteAnelAsync(int id)
    {
      var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
      response.EnsureSuccessStatusCode();
    }

    // Obter um anel específico por ID
    public async Task<Anel> GetAnelByIdAsync(int id)
    {
      var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");

      // Verificar se a requisição foi bem-sucedida
      if (response.IsSuccessStatusCode)
      {
        return await response.Content.ReadFromJsonAsync<Anel>();
      }
      else
      {
        var errorContent = await response.Content.ReadAsStringAsync();
        throw new Exception($"Erro ao obter anel: {response.StatusCode} - {errorContent}");
      }
    }

    public Task UpdateAnelAsync(Anel anel)
    {
      throw new NotImplementedException();
    }
  }
}
