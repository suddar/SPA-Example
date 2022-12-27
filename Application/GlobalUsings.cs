global using MediatR;
global using AutoMapper;
global using Newtonsoft.Json;

global using Application.MapperProfiles;
global using Application.Services;

global using Infrastructure;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;

global using Application.Commands.Abstractions;
global using Application.Exceptions;

global using Domain.Commands;
global using Domain.Entities.Abstractions;
global using Domain.Entities.LearningUnits;
global using Domain.Entities.Peoples;
global using Domain.Entities.Resources;
global using Domain.Entities.Validators;

global using Domain.Identity.Authentication;
global using Domain.Identity.Authorization;