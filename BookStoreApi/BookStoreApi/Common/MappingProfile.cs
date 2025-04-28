using AutoMapper;
using BookStoreApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreApi.Application.AuthorOperations.Queries.GetAuthors;
using BookStoreApi.Application.BookOperations.Command.CreateBook;
using BookStoreApi.Application.BookOperations.Queries.GetBookDetail;
using BookStoreApi.Application.BookOperations.Queries.GetBooks;
using BookStoreApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreApi.Entities;

namespace BookStoreApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Genre, GenresViewModel>();
        CreateMap<Genre, GenreDetailViewModel>();
        CreateMap<Author, AuthorsViewModel>();
        CreateMap<Author, AuthorDetailViewModel>();
        CreateMap<CreateAuthorCommand.CreateAuthorModel, Author>();
        
        
        
        
    }
    
}