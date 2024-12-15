using HotChocolate.Language;

namespace HireServices.Domain.Types
{
    public class CustomTimeSpanType : ScalarType<TimeSpan, StringValueNode>
    {
        public CustomTimeSpanType(string name, BindingBehavior bind = BindingBehavior.Explicit) : base(name, bind)
        {
        }

        public CustomTimeSpanType() : base("TimeSpan")
        {

        }

        public override IValueNode ParseResult(object? resultValue)
        {
            if (resultValue is TimeSpan timeSpan)
            {
                return new StringValueNode(timeSpan.ToString());
            }
            throw new SerializationException($"Unable to serialize {resultValue} as a TimeSpan", this);
        }

        protected override TimeSpan ParseLiteral(StringValueNode valueSyntax)
        {
            if(TimeSpan.TryParse(valueSyntax.Value, out var timeSpan))
            {
                return timeSpan;
            }
            throw new SerializationException($"Unable to parse{valueSyntax.Value} as a TimeSpan", this);
        }

        protected override StringValueNode ParseValue(TimeSpan runtimeValue)
        {
            return new StringValueNode(runtimeValue.ToString());
        }
        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            //return base.TrySerialize(runtimeValue, out resultValue);
            if(runtimeValue is TimeSpan timeSpan)
            {
                resultValue = timeSpan.ToString();
                return true;
            }
            resultValue = null;
            return false;
        }

        public override bool TryDeserialize(object? resultValue, out object? runtimeValue)
        {
            //return base.TryDeserialize(resultValue, out runtimeValue);
            if(resultValue is string str && TimeSpan.TryParse(str, out var timeSpan))
            {
                runtimeValue = timeSpan;
                return true;
            }
            runtimeValue = null;
            return false;
        }
    }
}
