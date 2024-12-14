using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;

namespace Application.Habits.Commands.EditHabit;

public record EditHabitCommand(Habit Habit, string ApplicationUserId) : ICommand<Result<Habit>>;
