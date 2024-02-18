using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
  internal sealed class Member : Entity
  {
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; set; }

    public Member(string firstName, string lastName, string gender, string email, bool? isActive)
    {
      ValidateDomain(firstName, lastName, gender, email, isActive);
    }

    public Member(int id, string firstName, string lastName, string gender, string email, bool? isActive)
    {
      DomainValidation.When(id < 0, "Invalid ID value.");
      Id = id;
      ValidateDomain(firstName, lastName, gender, email, isActive);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string? email, bool? isActive)
    {
      DomainValidation.When(
        string.IsNullOrEmpty(firstName),
        "Invalid name. FirstName is required");

      DomainValidation.When(
        firstName.Length < 3,
        "Invalid name. FirstName must have at least 3 characters");

      DomainValidation.When(
        string.IsNullOrEmpty(lastName),
        "Invalid lastname. LastName is required");

      DomainValidation.When(
        lastName.Length < 3,
        "Invalid lastname. LastName must have at least 3 characters");

      DomainValidation.When(
        email?.Length > 250,
        "Invalid email. Email must have at maximum 250 characters");

      DomainValidation.When(
        email?.Length < 6,
        "Invalid email. Email must have at least 250 characters");

      DomainValidation.When(
        !isActive.HasValue,
        "isActive must be informed");
    }
  }

}
