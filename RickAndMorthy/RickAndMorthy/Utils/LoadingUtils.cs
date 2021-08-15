using Acr.UserDialogs;

namespace RickAndMorthy.Utils
{
    public static class LoadingUtils
    {
        /// <summary>
        /// Shows the loading.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void ShowLoading(string message = "Loading...")
        {
            UserDialogs.Instance.ShowLoading(message, MaskType.Black);
        }

        /// <summary>
        /// Hides the loading.
        /// </summary>
        public static void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
