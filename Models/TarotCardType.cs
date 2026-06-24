namespace TgPredictBot.Models
{
    public enum TarotCardType
    {
        // === СТАРШИЕ АРКАНЫ (Major Arcana - 22 карты) ===
        Fool = 0, Magician, HighPriestess, Empress, Emperor,
        Hierophant, Lovers, Chariot, Strength, Hermit,
        WheelOfFortune, Justice, HangedMan, Death, Temperance,
        Devil, Tower, Star, Moon, Sun, Judgement, World,

        // === МЛАДШИЕ АРКАНЫ (Minor Arcana - 56 карт) ===

        // Масть Жезлы (Wands)
        AceOfWands = 101, TwoOfWands, ThreeOfWands, FourOfWands, FiveOfWands,
        SixOfWands, SevenOfWands, EightOfWands, NineOfWands, TenOfWands,
        PageOfWands, KnightOfWands, QueenOfWands, KingOfWands,

        // Масть Кубки (Cups)
        AceOfCups = 201, TwoOfCups, ThreeOfCups, FourOfCups, FiveOfCups,
        SixOfCups, SevenOfCups, EightOfCups, NineOfCups, TenOfCups,
        PageOfCups, KnightOfCups, QueenOfCups, KingOfCups,

        // Масть Мечи (Swords)
        AceOfSwords = 301, TwoOfSwords, ThreeOfSwords, FourOfSwords, FiveOfSwords,
        SixOfSwords, SevenOfSwords, EightOfSwords, NineOfSwords, TenOfSwords,
        PageOfSwords, KnightOfSwords, QueenOfSwords, KingOfSwords,

        // Масть Пентакли (Pentacles)
        AceOfPentacles = 401, TwoOfPentacles, ThreeOfPentacles, FourOfPentacles, FiveOfPentacles,
        SixOfPentacles, SevenOfPentacles, EightOfPentacles, NineOfPentacles, TenOfPentacles,
        PageOfPentacles, KnightOfPentacles, QueenOfPentacles, KingOfPentacles
    }
}