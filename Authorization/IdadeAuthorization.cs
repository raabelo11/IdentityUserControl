using Microsoft.AspNetCore.Authorization;

namespace IdentityUserControl.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dateOfBirth = context.User.FindFirst(claim => claim.Type == "DateOfBirth");

            if (dateOfBirth is null)
            {
                return Task.CompletedTask;
            }

            var dataNascimento = Convert.ToDateTime(dateOfBirth.Value);

            var userIdade = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-userIdade))
            {
                userIdade--;
            }

            if (userIdade >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
