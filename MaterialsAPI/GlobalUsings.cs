﻿global using MaterialsAPI.Data.DAL.Repositories;
global using MaterialsAPI.Data.Context;
global using MaterialsAPI.Utilties;
global using MaterialsAPI.Data.DAL;
global using AutoMapper;
global using MaterialsAPI.Data.Entities;
global using MaterialsAPI.DTOs.Author;
global using MaterialsAPI.DTOs.Material;
global using MaterialsAPI.DTOs.MaterialReview;
global using MaterialsAPI.DTOs.MaterialType;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using MaterialsAPI.Services;
global using Microsoft.AspNetCore.Authorization;
global using Swashbuckle.AspNetCore.Annotations;
global using MaterialsAPI.DTOs.User;
global using MaterialsAPI.Services.Interfaces;
global using MaterialsAPI.Data.DAL.Interfaces;
global using MaterialsAPI.UsersDATA;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using Microsoft.OpenApi.Models;
global using System.Reflection;
global using System.Text;
global using MaterialsAPI.MapperProfiles;
global using MaterialsAPI.Middlewares;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Serilog;
