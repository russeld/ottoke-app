using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;

namespace Application.Habits.Queries.GetYourDayHabits;

public record GetYourDayHabitsQuery(string ApplicationUserId) : IQuery<Result<List<Habit>>>;
