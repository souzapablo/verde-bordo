﻿using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
} 
