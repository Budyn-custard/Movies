using Microsoft.AspNetCore.Components;
using Movies.Models.ViewModels;

namespace Movies.UI.Components.Pages
{
    public partial class Home
    {
        [Inject]
        IConfiguration _configuration { get; set; }
        [Inject]
        HttpClient _httpClient { get; set; }

        List<MovieViewModel> movies = new List<MovieViewModel>();
        int take = 10;
        int skip = 0;
        int currentPage = 1;
        int selectedTakeValue = 10;
        bool isLoading = false;
        string selectedProperty { get; set; } = "Title";
        string filterValue { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadMovies();
        }

        private IEnumerable<string> GetMovieViewModelProperties()
        {
            var propertyNames = typeof(MovieViewModel).GetProperties()
                .Select(propertyInfo => propertyInfo.Name);

            return propertyNames;
        }

        private async Task ApplyFilter()
        {
            isLoading = true;
            var apiUrl = $"{_configuration.GetSection("MovieApiUrl").Value}?Take={take}&Skip={skip}&Filter={filterValue}&FilterByType={selectedProperty}";

            // Call the API to load movies with filters
            var response = await _httpClient.GetFromJsonAsync<List<MovieViewModel>>(apiUrl);

            if (response != null)
            {
                movies = response;
            }
            isLoading = false;
        }

        private async Task LoadMovies()
        {
            isLoading = true;
            var response = await _httpClient.GetFromJsonAsync<List<MovieViewModel>>(
                $"{_configuration.GetSection("MovieApiUrl").Value}?Take={take}&Skip={skip}");

            if (response != null)
            {
                movies = response;
            }
            isLoading = false;
        }

        private async Task LoadNextPage()
        {
            skip += take;
            currentPage++;
            await LoadMovies();
        }

        private async Task LoadPreviousPage()
        {
            if (skip >= take)
            {
                skip -= take;
                currentPage--;
                await LoadMovies();
            }
        }

        private async Task UpdateTakeValue(ChangeEventArgs e)
        {
            selectedTakeValue = int.Parse(e.Value.ToString());
            take = selectedTakeValue;
            skip = 0;
            currentPage = 1;
            await LoadMovies();
        }
    }
}
