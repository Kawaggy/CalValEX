﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles.Banners;

namespace CalValEX.Tiles.Banners
{
    public class SandTurtleBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            DustType = -1;
            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sand Turtle Banner");
            AddMapEntry(new Color(0, 255, 242), name);
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int frameY)
        {
            int style = TileFrameX / 18;
            string item;
            switch (style)
            {
                case 0:
                    item = "SandTurtleBanner";
                    break;

                default:
                    return;
            }
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<SandTurtleBanner>());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].TileFrameX / 18;
                string type;
                switch (style)
                {
                    case 0:
                        type = "SandTurtle";
                        break;

                    default:
                        return;
                }
                player.HasNPCBannerBuff(ModContent.NPCType<NPCs.Critters.SandTurtle>());
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}