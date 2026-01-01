using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    using Entities;
    using Repositories;
    using Microsoft.EntityFrameworkCore;
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    namespace Tests
    {
        public class UsersIntegrationTests : IClassFixture<ShopIntegrationFixture>, IDisposable
        {
            private readonly ShopIntegrationFixture _fixture;
            private readonly UsersReposetory _repository;

            public UsersIntegrationTests(ShopIntegrationFixture fixture)
            {
                _fixture = fixture;
                _fixture.CreateNewContext(); // Hook: איפוס ה-DB לפני כל טסט
                _repository = new UsersReposetory(_fixture.Context);
            }

            [Fact]
            public async Task AddNewUsersRepositories_ValidUser_SavesToDb()
            {
                // Arrange
                var newUser = new User { UserName = "newuser", Password = "password", FirstName = "Israel", LastName = "Israeli" };

                // Act
                var result = await _repository.AddNewUsersRepositories(newUser);

                // Assert
                var userInDb = await _fixture.Context.Users.FirstOrDefaultAsync(u => u.UserName == "newuser");
                userInDb.Should().NotBeNull();
                userInDb.FirstName.Should().Be("Israel");
            }

            [Fact]
            public async Task GetByIDUsersRepositories_ExistingId_ReturnsUser()
            {
                // Act
                var result = await _repository.GetByIDUsersRepositories(1);

                // Assert
                result.Should().NotBeNull();
                result.UserName.Should().Be("admin1");
            }

            [Fact]
            public async Task GetByIDUsersRepositories_NonExistingId_ReturnsNull()
            {
                // Act
                var result = await _repository.GetByIDUsersRepositories(999);

                // Assert
                result.Should().BeNull();
            }

            [Fact]
            public async Task LoginUsersRepositories_CorrectCredentials_ReturnsUser()
            {
                // Arrange
                var loginInfo = new User { UserName = "admin1", Password = "p1" };

                // Act
                var result = await _repository.LoginUsersRepositories(loginInfo);

                // Assert
                result.Should().NotBeNull();
                result.UserId.Should().Be(1);
            }

            [Fact]
            public async Task LoginUsersRepositories_WrongPassword_ReturnsNull()
            {
                // Arrange
                var loginInfo = new User { UserName = "admin1", Password = "wrong" };

                // Act
                var result = await _repository.LoginUsersRepositories(loginInfo);

                // Assert
                result.Should().BeNull();
            }

            [Fact]
            public async Task UpdateUsersRepositories_ExistingUser_UpdatesCorrectly()
            {
                // Arrange
                var userToUpdate = await _fixture.Context.Users.FindAsync((short)1);
                _fixture.Context.Entry(userToUpdate).State = EntityState.Detached; // ניתוק מה-Tracker

                userToUpdate.FirstName = "UpdatedName";

                // Act
                await _repository.UpdateUsersRepositories(1, userToUpdate);

                // Assert
                var updatedUser = await _fixture.Context.Users.FindAsync((short)1);
                updatedUser.FirstName.Should().Be("UpdatedName");
            }

            [Fact]
            public async Task CheckIfUsersInsistalrady_UserDoesNotExist_ReturnsTrue()
            {
                // בשם הפונקציה שלך: True אומר שהמשתמש *לא* קיים (זמין להרשמה)
                // Act
                var result = await _repository.CheckIfUsersInsistalrady("available_user");

                // Assert
                result.Should().BeTrue();
            }

            [Fact]
            public async Task CheckIfUsersInsistalrady_UserExists_ReturnsFalse()
            {
                // Act
                var result = await _repository.CheckIfUsersInsistalrady("admin1");

                // Assert
                result.Should().BeFalse();
            }

            public void Dispose()
            {
                _fixture.Context.Database.EnsureDeleted();
            }
        }
    }
}
