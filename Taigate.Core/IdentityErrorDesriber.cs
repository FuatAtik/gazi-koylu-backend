using Microsoft.AspNetCore.Identity;

namespace Taigate.Core
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError {Code = nameof(DefaultError), Description = $"Bir sorunla karşılaşıldı."};
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError {Code = nameof(ConcurrencyFailure), Description = "Concurrency hatası."};
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError {Code = nameof(PasswordMismatch), Description = "Şifre yanlış."};
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
                {Code = nameof(InvalidToken), Description = "Yeniden şifre yenileme e-postası isteyin."};
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError {Code = nameof(LoginAlreadyAssociated), Description = "Kullanıcı girişi mevcut."};
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = $"Kullanıcı adı '{userName}' geçersiz. Sadece rakam ve harf kullanabilirsiniz."
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError {Code = nameof(InvalidEmail), Description = $"E-posta hesabı '{email}' geçersiz."};
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"Kullanıcı adı '{userName}' başka bir kullanıcı tarafından kullanılıyor."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"E-posta '{email}' başka bir kullanıcı tarafından kullanılıyor."
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError {Code = nameof(InvalidRoleName), Description = $"Rol '{role}' geçersiz."};
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError {Code = nameof(DuplicateRoleName), Description = $"Rol '{role}' kullanılıyor."};
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
                {Code = nameof(UserAlreadyHasPassword), Description = "Kullanıcı için zaten bir şifre belirlenmiş."};
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
                {Code = nameof(UserLockoutNotEnabled), Description = "Kullanıcı için kilitleme etkin değil."};
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
                {Code = nameof(UserAlreadyInRole), Description = $"Kullanıcıya atanmış bir rol mevcut'{role}'."};
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
                {Code = nameof(UserNotInRole), Description = $"Kullanıcı gerekli rol'e sahip değil '{role}'."};
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
                {Code = nameof(PasswordTooShort), Description = $"Şifre en az {length} karakter olmalıdır."};
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Şizrenizden en az bir adet özel karakter bulunmalıdır."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
                {Code = nameof(PasswordRequiresDigit), Description = "Şifrenizde en az bir rakam olmalıdır ('0'-'9')."};
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Şifrenizde en az bir adet küçük harf bulunmalıdır ('a'-'z')."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Şifrenizde en az bir adet büyük harf bulunmalıdır ('A'-'Z')."
            };
        }
    }
}