﻿using AutoMapper;
using BlogEngine.Core.Enums;
using BlogEngine.Service.Database.Entities;
using BlogEngine.Service.Models;

namespace BlogEngine.Service.Mapping;

/// <summary>
///     Профиль для маппинга
/// </summary>
internal class MappingProfile : Profile
{
    /// <inheritdoc />
    public MappingProfile()
    {
        CreateMap<RegisterContract, UserEntity>()
            .ForMember(d => d.PasswordHash, s => s.MapFrom(m => m.Password))
            .ForMember(d => d.Role, s => s.MapFrom(m => UserRole.USER))
            .ForPath(d => d.UserInfo.Nickname, s => s.MapFrom(m => m.Nickname))
            .ForPath(d => d.UserInfo.FirstName, s => s.MapFrom(m => m.FirstName))
            .ForPath(d => d.UserInfo.LastName, s => s.MapFrom(m => m.LastName))
            .ForPath(d => d.UserInfo.Image.Base64, s => s.MapFrom(m => m.Image))
            .ForPath(d => d.UserInfo.Image.Width, s => s.MapFrom(m => m.Width))
            .ForPath(d => d.UserInfo.Image.Height, s => s.MapFrom(m => m.Height))
            .ReverseMap();

        CreateMap<UserContract, UserEntity>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.PasswordHash, s => s.Ignore())
            .ForMember(d => d.Role, s => s.MapFrom(m => m.Role))
            .ForPath(d => d.UserInfo.Nickname, s => s.MapFrom(m => m.Nickname))
            .ForPath(d => d.UserInfo.Id, s => s.MapFrom(m => m.Id))
            .ForPath(d => d.UserInfoId, s => s.MapFrom(m => m.Id))
            .ForPath(d => d.UserInfo.FirstName, s => s.MapFrom(m => m.FirstName))
            .ForPath(d => d.UserInfo.LastName, s => s.MapFrom(m => m.LastName))
            .ForPath(d => d.UserInfo.Image.Base64, s => s.MapFrom(m => m.Image))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForPath(d => d.UserInfo.Updated, s => s.MapFrom(m => m.Updated))
            .ReverseMap();

        CreateMap<CommentContract, CommentEntity>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForMember(d => d.ArticleId, s => s.MapFrom(m => m.ArticleId))
            .ForPath(d => d.UserInfo.Nickname, s => s.MapFrom(m => m.Author.Nickname))
            .ForPath(d => d.UserInfo.FirstName, s => s.MapFrom(m => m.Author.FirstName))
            .ForPath(d => d.UserInfo.LastName, s => s.MapFrom(m => m.Author.LastName))
            .ForPath(d => d.UserInfo.Image.Base64, s => s.MapFrom(m => m.Author.Image))
            .ForMember(d => d.Text, s => s.MapFrom(m => m.Text))
            .ReverseMap();

        CreateMap<ArticleContract, ArticleEntity>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForPath(d => d.UserInfo.Id, s => s.MapFrom(m => m.Author.Id))
            .ForPath(d => d.UserInfoId, s => s.MapFrom(m => m.Author.Id))
            .ForPath(d => d.UserInfo.Nickname, s => s.MapFrom(m => m.Author.Nickname))
            .ForPath(d => d.UserInfo.FirstName, s => s.MapFrom(m => m.Author.FirstName))
            .ForPath(d => d.UserInfo.LastName, s => s.MapFrom(m => m.Author.LastName))
            .ForPath(d => d.UserInfo.Image.Base64, s => s.MapFrom(m => m.Author.Image))
            .ForMember(d => d.Description, s => s.MapFrom(m => m.Description))
            .ForMember(d => d.Header, s => s.MapFrom(m => m.Header))
            .ForMember(d => d.Comments, s => s.MapFrom(m => m.Comments))
            .ForPath(d => d.LeadingImage.Base64, s => s.MapFrom(m => m.LeadingImage))
            .ReverseMap();

        CreateMap<ArticleContract, ArticleEntity>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.IssueId, s => s.MapFrom(m => m.IssueId))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForPath(d => d.UserInfoId, s => s.MapFrom(m => m.Author.Id))
            .ForMember(d => d.Description, s => s.MapFrom(m => m.Description))
            .ForMember(d => d.Header, s => s.MapFrom(m => m.Header))
            .ForMember(d => d.Comments, s => s.MapFrom(m => m.Comments))
            .ForMember(d => d.Tags, s => s.MapFrom(m => m.Tags))
            .ForPath(d => d.LeadingImage.Base64, s => s.MapFrom(m => m.LeadingImage));

        CreateMap<ArticleEntity, ArticleContract>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.IssueId, s => s.MapFrom(m => m.IssueId))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForPath(d => d.Author.Nickname, s => s.MapFrom(m => m.UserInfo.Nickname))
            .ForPath(d => d.Author.FirstName, s => s.MapFrom(m => m.UserInfo.FirstName))
            .ForPath(d => d.Author.LastName, s => s.MapFrom(m => m.UserInfo.LastName))
            .ForPath(d => d.Author.Image, s => s.MapFrom(m => m.UserInfo.Image.Base64))
            .ForMember(d => d.Description, s => s.MapFrom(m => m.Description))
            .ForMember(d => d.Header, s => s.MapFrom(m => m.Header))
            .ForMember(d => d.Tags, s => s.MapFrom(m => m.Tags))
            .ForMember(d => d.Comments, s => s.MapFrom(m => m.Comments))
            .ForPath(d => d.LeadingImage, s => s.MapFrom(m => m.LeadingImage.Base64));

        CreateMap<IssueEntity, IssueContract>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.Pdf, s => s.MapFrom(m => m.Pdf))
            .ForMember(d => d.IssueNumber, s => s.MapFrom(m => m.IssueNumber))
            .ForMember(d => d.Date, s => s.MapFrom(m => m.Date.ToDateTime(TimeOnly.MinValue)))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForPath(d => d.LeadingImage, s => s.MapFrom(m => m.LeadingImage.Base64))
            .ForMember(d => d.ArticleIds, s => s.MapFrom(m => m.Articles.Select(t => t.Id)));

        CreateMap<IssueContract, IssueEntity>()
            .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
            .ForMember(d => d.Pdf, s => s.MapFrom(m => m.Pdf))
            .ForMember(d => d.IssueNumber, s => s.MapFrom(m => m.IssueNumber))
            .ForMember(d => d.Date, s => s.MapFrom(m => DateOnly.FromDateTime(m.Date)))
            .ForMember(d => d.Created, s => s.MapFrom(m => m.Created))
            .ForMember(d => d.Updated, s => s.MapFrom(m => m.Updated))
            .ForPath(d => d.LeadingImage.Base64, s => s.MapFrom(m => m.LeadingImage))
            .ForMember(d => d.Articles, s => s.MapFrom(m => m.ArticleIds.Select(t => new ArticleEntity { Id = t })));
    }
}
