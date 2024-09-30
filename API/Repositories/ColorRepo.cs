using API.Data;
using API.DTO;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class ColorRepo : IColorRepo
	{
		private readonly ApplicationDbContext _context;
		public ColorRepo(ApplicationDbContext ColorRepo)
		{
			_context = ColorRepo;
		}
		public async Task Create(Color Color)
		{
			if (await GetColorById(Color.Id) != null) throw new DuplicateWaitObjectException($"Color : {Color.Id} is existed!");
			await _context.Colors.AddAsync(Color);
		}

		public async Task Delete(Guid id)
		{
			var Color = await GetColorById(id);
			if (Color == null) throw new KeyNotFoundException("Not found this Color!");
			if (_context.ProductDetails.Where(p => p.ColorId == id).Any()) throw new Exception("This color has used for some product!");
			_context.Colors.Remove(Color);
		}

		public async Task<List<Color>> GetAllColor()
		{
			return await _context.Colors.ToListAsync();
		}

		public async Task<Color> GetColorById(Guid id)
		{
			return await _context.Colors.FindAsync(id);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Update(Color Color)
		{
			if (await GetColorById(Color.Id) == null) throw new KeyNotFoundException("Not found this color!");
			_context.Entry(Color).State = EntityState.Modified;
		}
	}

	public class ImageRepo : IImageRepo
	{
		private readonly ApplicationDbContext _context;
		public ImageRepo(ApplicationDbContext ImageRepo)
		{
			_context = ImageRepo;
		}
		public async Task Create(ImageDTO Image)
		{
			if (await GetImageById(Image.Id) != null) throw new DuplicateWaitObjectException($"Image : {Image.Id} is existed!");
			Image data = new Image()
			{
				Id = Image.Id,
				ColorId = Image.ColorId,
				URL = Image.URL,
			};
			await _context.Images.AddAsync(data);
		}

		public async Task Delete(Guid id)
		{
			var Image = await GetImageById(id);
			if (Image == null) throw new KeyNotFoundException("Not found this Image!");
			_context.Images.Remove(Image);
		}

		public async Task<List<Image>> GetAllImage()
		{
			return await _context.Images.ToListAsync();
		}

		public async Task<Image> GetImageById(Guid id)
		{
			return await _context.Images.FindAsync(id);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Update(ImageDTO Image)
		{
			if (await GetImageById(Image.Id) == null) throw new KeyNotFoundException("Not found this Image!");
			Image data = new Image()
			{
				Id = Image.Id,
				ColorId = Image.ColorId,
				URL = Image.URL,
			};
			_context.Entry(data).State = EntityState.Modified;
		}
	}

	public class SelectedImageRepo : ISelectedImageRepo
	{
		private readonly ApplicationDbContext _context;
		public SelectedImageRepo(ApplicationDbContext SelectedImageRepo)
		{
			_context = SelectedImageRepo;
		}
		public async Task Create(SelectedImageDTO SelectedImage)
		{
			if (await GetSelectedImageById(SelectedImage.Id) != null) throw new DuplicateWaitObjectException($"SelectedImage : {SelectedImage.Id} is existed!");
			SelectedImage data = new SelectedImage()
			{
				Id = SelectedImage.Id,
				ColorId = SelectedImage.ColorId,
				URL = SelectedImage.URL,
				ProductId = SelectedImage.ProductId,
			};
			await _context.SelectedImages.AddAsync(data);
		}

		public async Task Delete(Guid id)
		{
			var SelectedImage = await GetSelectedImageById(id);
			if (SelectedImage == null) throw new KeyNotFoundException("Not found this SelectedImage!");
			_context.SelectedImages.Remove(SelectedImage);
		}

		public async Task<List<SelectedImage>> GetAllSelectedImage()
		{
			return await _context.SelectedImages.ToListAsync();
		}

		public async Task<SelectedImage> GetSelectedImageById(Guid id)
		{
			return await _context.SelectedImages.FindAsync(id);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Update(SelectedImageDTO SelectedImage)
		{
			if (await GetSelectedImageById(SelectedImage.Id) == null) throw new KeyNotFoundException("Not found this SelectedImage!");
			SelectedImage data = new SelectedImage()
			{
				Id = SelectedImage.Id,
				ColorId = SelectedImage.ColorId,
				URL = SelectedImage.URL,
				ProductId = SelectedImage.ProductId
			};
			_context.Entry(data).State = EntityState.Modified;
		}
	}
}
