using Microsoft.AspNetCore.Html;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace MsBot.Implementation.Template.Razor.Internal.Buffering;

/// <summary>
/// Encapsulates a string or <see cref="IHtmlContent"/> value.
/// </summary>
[DebuggerDisplay("{DebuggerToString()}")]
public struct ViewBufferValue
{
    /// <summary>
    /// Initializes a new instance of <see cref="ViewBufferValue"/> with a <c>string</c> value.
    /// </summary>
    /// <param name="value">The value.</param>
    public ViewBufferValue(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ViewBufferValue"/> with a <see cref="IHtmlContent"/> value.
    /// </summary>
    /// <param name="content">The <see cref="IHtmlContent"/>.</param>
    public ViewBufferValue(IHtmlContent content)
    {
        Value = content;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public object Value { get; }

    private string DebuggerToString()
    {
        using (var writer = new StringWriter())
        {
            var valueAsString = Value as string;
            if (valueAsString != null)
            {
                writer.Write(valueAsString);
                return writer.ToString();
            }

            var valueAsContent = Value as IHtmlContent;
            if (valueAsContent != null)
            {
                valueAsContent.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }

            return "(null)";
        }
    }
}
