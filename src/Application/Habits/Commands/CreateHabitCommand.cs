using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;
using Core.Habits.Models;

namespace Application.Habits.Commands;

public record CreateHabitCommand(CreateHabitInputModel InputModel, string ApplicationUserId) : ICommand<Result<Habit>>;
