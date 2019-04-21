namespace Tinder.Net.Objects
{
    //Just incase anyone sees this and decides to get angry: These are the only values Tinder has. There is no 'other' option afaik
    /// <summary>
    /// Gender Enum
    /// </summary>
    public enum Gender : int
    {
        /// <summary>
        /// 0 represents male
        /// </summary>
        Male = 0,

        /// <summary>
        /// 1 represents female
        /// </summary>
        Female = 1,

        /// <summary>
        /// 2 represents both genders, used in gender preference
        /// </summary>
        MaleAndFemale = 2
    }
}
