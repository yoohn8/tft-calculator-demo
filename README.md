# tft-calculator-demo

## Disclaimer
I do not claim this is 100% accurate or even close.

I have currently not done extensive testing to determine accuracy, but have only implemented mechanics to the best of my knowledge and ability.

Some assumptions made for how DPS is calculated is that the chosen unit is standing still and always attacking and casting.

Imagine a unit attacking an unkillable training dummy where they aren't moving, changing targets, or getting CC'd. 

Many generalizations have been made like the durability for steadfast heart and shields are expected to have full value.

A full list of these generalizations will eventually be made.

The 15 second mark is not actually 15 seconds its an approximation.

For example if a unit cast started at 14 seconds and ended at 16 seconds this event and its stats will be included in the stats for 15 seconds.

When an event crosses the 15 second mark the end of that event is when the stats are collected.

## Summary
A TFT calculator for set 15 K.O. Coliseum.

Choose a unit, items, and augments to calculate their DPS and other stats.

Power ups (fruits) not yet included.

Stuff it can calculate:
- DPS at 15 and 30 seconds
- all of a units stats like hp, ad, crit, ap, etc
- scaling item stats like kraken, rageblade, and archangels
- number of attacks and casts at 15 and 30 seconds
- effective hp and phys/magic damage reduction
- and more

## Items
Every craftable item is available.

No artifacts, augment specific items, or emblems YET.

Some items are conditional so they have been generalized:
- Titans max stats is granted at 15 seconds
- titans currently only grant max stats to melee units (currently voli only)
- steadfast heart durability is averaged
- some secondary effects are not shown because they haven't been implemented in general like burning.

The item DPS comparison list shows what items gives the most DPS increase.

This has a toggle to change between DPS at 15 and 30 seconds.

## Augments
Some augments have conditional effects and some controls are included to make them work.

Gold augments:
- PairOfFours
- BestFriends2
- LittleBuddies
- MacesWill
- Preparation2
- ScoreboardScrapper
- BackUpDancers
- BlazingSoul2
- GlassCannon2
- CyberImplants2
- CyberUplink2
- ItemCollector2
- KnowYourEnemy
- PumpingUp2
- SpearsWill
- WaterLotus
- Ascension

No silver or prismatic augments YET.

Some augments have been simplified like pumping up and scoreboard scrapper to just give a static stat increase.

## Units
Only 4 cost units are in and all tanks currently only calculate tank related stats.

DPS calculations are available for:
- Jinx
- Karma
- Ryze
- Yuumi
- Akali
- Volibear
- Ashe
- Samira

Some units do AoE damage. Use the "# of Extra Targets" to reflect this.

## Traits
Only traits that are related to 4 costs have been implemented.

Some traits have conditional effects and a button is included to control them.

For example, theres a button to enable bastion's doubling their resistance bonus.

Starguardian is not implemented at all except for Jinx's attack speed increase.




