using System.Text;

namespace MsBot.Infrastructure;

/// <summary>
/// 随机辅助
/// </summary>
public class RandomHelper
{
    private static RandomHelper _instance;

    /// <summary>
    /// The rand
    /// </summary>
    private readonly Random _rand = new(unchecked((int)DateTime.Now.Ticks));

    /// <summary>
    /// The rand character
    /// </summary>
    private readonly char[] _randChar =
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
        'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F',
        'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    private RandomHelper()
    {
    }

    /// <summary>
    /// 实例
    /// </summary>
    public static RandomHelper Instance => _instance ??= new RandomHelper();

    /// <summary>
    /// Get a random integer.
    /// </summary>
    /// <param name="maxValue">The maximum value.</param>
    public int RandomInt(int maxValue)
    {
        return _rand.Next(maxValue);
    }

    /// <summary>
    /// Get a random integer.
    /// </summary>
    /// <param name="minValue">The min value</param>
    /// <param name="maxValue">The maximum value.</param>
    public int RandomInt(int minValue, int maxValue)
    {
        return _rand.Next(minValue, maxValue);
    }

    /// <summary>
    /// Get a random string by pattern string
    /// </summary>
    /// <param name="pattern">
    /// pattern string
    /// <para>"?" means a character</para>
    /// <para>"#" means a number</para>
    /// <para>"*" means a number or a character</para>
    /// </param>
    /// <param name="caseSensitive">whether case sensitive</param>
    public string RandomString(string pattern, bool caseSensitive = false)
    {
        if (!pattern.Contains("#") && !pattern.Contains("?") && !pattern.Contains("*"))
        {
            return pattern;
        }

        var nums = pattern.ToCharArray();
        var sb = new StringBuilder();
        for (var i = 0; i < nums.Length; i++)
        {
            switch (nums[i])
            {
                case '?':
                    nums[i] = caseSensitive ? _randChar[_rand.Next(10, 35)] : _randChar[_rand.Next(10, 62)];
                    break;
                case '#':
                    nums[i] = _randChar[_rand.Next(0, 10)];
                    break;
                case '*':
                    nums[i] = caseSensitive ? _randChar[_rand.Next(35)] : _randChar[_rand.Next(62)];
                    break;
            }

            sb.Append(nums[i]);
        }

        return sb.ToString();
    }
}