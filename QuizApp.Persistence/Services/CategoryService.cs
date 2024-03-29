﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Category.Commands.DeleteCategory;
using QuizApp.Application.Features.Category.Queries.GetAllCategories;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryWriteRepository _writeRepository;
    private readonly ICategoryReadRepository _readRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryWriteRepository writeRepository, IMapper mapper, ICategoryReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _readRepository = readRepository;
    }

    public async Task CreateCategory(CreateCategoryCommand request)
    {
        await CheckIfCategoryNameExists(request.CategoryName);
        var mapped = _mapper.Map<Category>(request);
        await _writeRepository.AddAsync(mapped);
        await _writeRepository.SaveAsync();
    }

    public async Task DeleteCategory(DeleteCategoryCommand request)
    {
        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveAsync();
    }

    public async Task<List<CategoryDto>> GetAllCategories(GetAllCategoriesQuery request)
    {
        List<CategoryDto> categories = await _readRepository
            .GetAll(false)
            .Select(x => new CategoryDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
            })
            .ToListAsync();
        return categories;
    }

    private async Task CheckIfCategoryNameExists(string categoryName)
    {
        var result = await _readRepository.GetSingleAsync(x => x.CategoryName == categoryName,false);
        if (result != null)
            throw new BusinessException(Messages.DuplicateObject(nameof(Category)));
    }
}
