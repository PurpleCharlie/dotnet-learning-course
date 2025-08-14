using System.Text.Json;

namespace Using_external_API_lesson_3;

// Пример использования HttpClient и JsonSerializer для отправки и получения по HTTP, а также сериализации/десериализации JSON
internal class Program
{
    static HttpClient client = new();
    private readonly static string API_KEY = "40427f4d8e375db868cdce2814e0f4ba3ee6952c";

    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите ИНН организации (10 цифр): ");
            string inn = Console.ReadLine()?.Trim() ?? string.Empty;

            try
            {
                var organization = await GetNameOrganizationAsync(inn);
                
                foreach (var suggestion in organization.Suggestions)
                {
                    Console.WriteLine($"Название организации: {suggestion.value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения или 'q' для выхода.");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q)
            {
                break;
            }
        } 
    }

    static async Task<ResponseData> GetNameOrganizationAsync(string innOrganization)
    {
        if (!(innOrganization.Length is 10 or 12) || !innOrganization.All(char.IsDigit))
            throw new ArgumentException("ИНН организации должен содержать 10 или 12 цифр", nameof(innOrganization));

        /*          Сборка заголовков и тела запроса            */
        using HttpRequestMessage request = new(HttpMethod.Post, "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", API_KEY);
        request.Headers.Add("Accept", "application/json");

        var payload = new { query = innOrganization };
        var jsonPayload = JsonSerializer.Serialize(payload);
        request.Content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

        /*          Отправка запроса и обработка ответа            */
        using var response = await client.SendAsync(request);   // Чтение ответа из сокета
        Stream data;
        data = await response.Content.ReadAsStreamAsync();      // Чтение тела ответа из буфера

        var option = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true  // Игнорирование регистра (для поля Suggestions, просто для примера)
        };
        var readyData = JsonSerializer.Deserialize<ResponseData>(data, option);

        return readyData ?? throw new InvalidOperationException("Не удалось получить название организации.");

    }
}

record ResponseData(List<Suggestion> Suggestions);
record Suggestion(string value);