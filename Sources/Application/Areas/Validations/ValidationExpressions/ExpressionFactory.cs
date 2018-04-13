using Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions.CoreValidationExpressions;

namespace Mmu.Mlh.WpfExtensions.Areas.Validations.ValidationExpressions
{
    public static class ExpressionFactory
    {
        public static StringLengthExpression StringLength(int minLength, int maxLength) => new StringLengthExpression(minLength, maxLength);

        public static StringNotNullOrEmptyExpression StringNotNullOrEmpty() => new StringNotNullOrEmptyExpression();
    }
}