﻿using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class BloodstoneBrick : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 0;
            item.useTurn = true;
            item.rare = 0;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<BloodstoneBrickPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient((ItemID.StoneBlock), 200);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodstoneCore"), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this, 200);
                recipe.AddRecipe();
                /*ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ModContent.ItemType<BloodstoneBrickWall>(), 4);
                recipe2.AddTile(TileID.WorkBenches);
                recipe2.SetResult(this, 4);
                recipe2.AddRecipe();*/
            }
        }
    }
}