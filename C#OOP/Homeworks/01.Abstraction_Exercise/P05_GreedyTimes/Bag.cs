namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private Dictionary<string, Dictionary<string, long>> bagSpace;

        public Bag()
        {
            this.bagSpace = new Dictionary<string, Dictionary<string, long>>();
        }

        public void FillBag(string[] seif, long bagCapacity)
        {
            long goldQuantity = 0;
            long gemQuantity = 0;
            long cashQuantity = 0;
            for (int i = 0; i < seif.Length; i += 2)
            {
                string itemName = seif[i];
                long itemAmount = long.Parse(seif[i + 1]);
                string itemType = FindItem(itemName);

                if (itemType == "")
                {
                    continue;
                }
                else if (bagCapacity < bagSpace.Values.Select(x => x.Values.Sum()).Sum() + itemAmount)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bagSpace.ContainsKey(itemType))
                        {
                            if (bagSpace.ContainsKey("Gold"))
                            {
                                if (itemAmount > bagSpace["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagSpace[itemType].Values.Sum() + itemAmount > bagSpace["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bagSpace.ContainsKey(itemType))
                        {
                            if (bagSpace.ContainsKey("Gem"))
                            {
                                if (itemAmount > bagSpace["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagSpace[itemType].Values.Sum() + itemAmount > bagSpace["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                InitializeBagSpaceDictionary(itemName, itemAmount, itemType);
                CalqulateItemQuantity(ref goldQuantity, ref gemQuantity, ref cashQuantity, itemAmount, itemType);
            }
        }

        private void InitializeBagSpaceDictionary(string itemName, long itemAmount, string itemType)
        {
            if (!bagSpace.ContainsKey(itemType))
            {
                bagSpace[itemType] = new Dictionary<string, long>();
            }

            if (!bagSpace[itemType].ContainsKey(itemName))
            {
                bagSpace[itemType][itemName] = 0;
            }

            bagSpace[itemType][itemName] += itemAmount;
        }

        private static void CalqulateItemQuantity(ref long goldQuantity, ref long gemQuantity, ref long cashQuantity, long itemAmount, string itemType)
        {
            if (itemType == "Gold")
            {
                goldQuantity += itemAmount;
            }
            else if (itemType == "Gem")
            {
                gemQuantity += itemAmount;
            }
            else if (itemType == "Cash")
            {
                cashQuantity += itemAmount;
            }
        }

        private static string FindItem(string itemName)
        {
            string itemType = string.Empty;

            if (itemName.Length == 3)
            {
                itemType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var bag in bagSpace)
            {
                builder.AppendLine($"<{bag.Key}> ${bag.Value.Values.Sum()}");
                foreach (var item2 in bag.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    builder.AppendLine($"##{item2.Key} - {item2.Value}");
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
