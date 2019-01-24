using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace Cognifide.PowerShell
{
    public static class WebDAVItemUtil
    {
        public static bool IsVersioned(Item item)
        {
            MediaData mediaData = new MediaData(new MediaItem(item));
            Field field = item.Fields[mediaData.DataFieldName];
            if (!field.Shared)
            {
                return !field.Unversioned;
            }

            return false;
        }

        public static bool IsMediaItem(Item item, string dataFieldName)
        {
            if (!item.Paths.IsMediaItem)
            {
                return false;
            }

            return item.Template.GetField(dataFieldName) != null;
        }
    }
}