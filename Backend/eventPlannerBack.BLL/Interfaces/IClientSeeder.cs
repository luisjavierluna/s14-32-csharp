﻿namespace eventPlannerBack.BLL.Interfaces
{
    public interface IClientSeeder
    {
        public Task CreateUserAdmin();

        public Task CreateRoles();
    }
}
