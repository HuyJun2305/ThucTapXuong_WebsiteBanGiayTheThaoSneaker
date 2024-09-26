using DataProcessing.Models;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
	public class ColorServices : IColorServices
	{
		private readonly HttpClient _httpClient;

		public ColorServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task Create(Color color)
		{
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/Colors", color);
		}

		public async Task Delete(Guid id)
		{
			await _httpClient.DeleteAsync($"https://localhost:7170/api/Colors/{id}");
		}

		public async Task<IEnumerable<Color>?> GetAllColors()
		{
			var colors = JsonConvert.DeserializeObject<IEnumerable<Color>>("https://localhost:7170/api/Colors");
			return colors;
		}

		public async Task<Color?> GetColorById(Guid id)
		{
			var color = JsonConvert.DeserializeObject<Color>($"https://localhost:7170/api/Colors/{id}");
			return color;
		}

		public async Task Update(Color color)
		{
			await _httpClient.PutAsJsonAsync("https://localhost:7170/api/Colors", color);
		}
	}

	public class ImageServices : IImageServices
	{
		private readonly HttpClient _httpClient;

		public ImageServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task Create(Image Image)
		{
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/Images", Image);
		}

		public async Task Delete(Guid id)
		{
			await _httpClient.DeleteAsync($"https://localhost:7170/api/Images/{id}");
		}

		public async Task<IEnumerable<Image>?> GetAllImages()
		{
			var Images = JsonConvert.DeserializeObject<IEnumerable<Image>>("https://localhost:7170/api/Images");
			return Images;
		}

		public async Task<Image?> GetImageById(Guid id)
		{
			var Image = JsonConvert.DeserializeObject<Image>($"https://localhost:7170/api/Images/{id}");
			return Image;
		}

		public async Task Update(Image Image)
		{
			await _httpClient.PutAsJsonAsync("https://localhost:7170/api/Images", Image);
		}
	}

	public class SelectedImageServices : ISelectedImageServices
	{
		private readonly HttpClient _httpClient;

		public SelectedImageServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task Create(SelectedImage SelectedImage)
		{
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/SelectedImages", SelectedImage);
		}

		public async Task Delete(Guid id)
		{
			await _httpClient.DeleteAsync($"https://localhost:7170/api/SelectedImages/{id}");
		}

		public async Task<IEnumerable<SelectedImage>?> GetAllSelectedImages()
		{
			var SelectedImages = JsonConvert.DeserializeObject<IEnumerable<SelectedImage>>("https://localhost:7170/api/SelectedImages");
			return SelectedImages;
		}

		public async Task<SelectedImage?> GetSelectedImageById(Guid id)
		{
			var SelectedImage = JsonConvert.DeserializeObject<SelectedImage>($"https://localhost:7170/api/SelectedImages/{id}");
			return SelectedImage;
		}

		public async Task Update(SelectedImage SelectedImage)
		{
			await _httpClient.PutAsJsonAsync("https://localhost:7170/api/SelectedImages", SelectedImage);
		}
	}
}
