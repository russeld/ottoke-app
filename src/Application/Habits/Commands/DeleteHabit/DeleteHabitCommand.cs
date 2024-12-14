using Buna.Result;
using Buna.SharedKernel;

namespace Application.Habits.Commands.DeleteHabit;

public record DeleteHabitCommand(int HabitId, string ApplicationId) : ICommand<Result>;
