using LibraryFor2ndLab.Models.Person;
using System;

namespace Lab_2.Utilities
{
    class UserUtility
    {
        private static readonly string[] usernames = new string[] {
            "spiritedpresident", "planetragefilled", "groovydowntown",
            "artichokenewspaper", "scratchynobody", "awfulcodger",
            "mereconcur", "puckmortgage", "dufusnetherrack",
            "channelingpaddleball", "dishdew", "pilothit",
            "grammarianunpack", "churchcalm", "prickcooked",
            "rhetoricaljunior", "profitableearnest", "disturbedpoof",
            "milkgovern", "constantlyreassuring", "perbreathe",
            "scrollpig", "citysynonymous", "golfingvhs",
            "boughtcheesecake"
        };

        private static readonly string[] emails = new string[] {
            "spiritedpresident@gmail.com", "planetragefilled@gmail.com", "groovydowntown@gmail.com",
            "artichokenewspaper@gmail.com", "scratchynobody@gmail.com", "awfulcodger@gmail.com",
            "mereconcur@gmail.com", "puckmortgage@gmail.com", "dufusnetherrack@gmail.com",
            "channelingpaddleball@gmail.com", "dishdew@gmail.com", "pilothit@gmail.com",
            "grammarianunpack@gmail.com", "churchcalm@gmail.com", "prickcooked@gmail.com",
            "rhetoricaljunior@gmail.com", "profitableearnest@gmail.com", "disturbedpoof@gmail.com",
            "milkgovern@gmail.com", "constantlyreassuring@gmail.com", "perbreathe@gmail.com",
            "scrollpig@gmail.com", "citysynonymous@gmail.com", "golfingvhs@gmail.com",
            "boughtcheesecake@gmail.com"
        };

        private static readonly string[] phones = new string[]{
            "0968610687", "+380999655405", "+380932433960", "+380676394352", "0931428050",
            "0990616663", "+380671162655", "0993754020", "+380994014429", "+380930348432",
            "0994509394", "+380932093267", "+38(070)7403659", "0939448183", "0632585350",
            "+38(088)3315463", "+380994343089", "0932766426", "0500368893", "+38(0880)053912",
            "+380637598550", "0505113853", "+380966901944", "0630083726", "0966122829"};

        private static readonly string[] passwords = new string[]{
            "UYX6RdTLH0", "UppYxBEo1J", "CHfoOIn3vU", "SX26Yyid1D", "h4e4PQvFzv",
            "SxX7z3oY24", "XfVO0sMBy6", "fCqMCwM71J", "hukU1wd92L", "xOJjV9oICs",
            "HCBV9wziPn", "zzQq23e0S0", "a84JFEoDRu", "ETN1ifkb6x", "JTHpyw0Qun",
            "nW4FEM8T9M", "SIyp1mOg1O", "TWyznu2HsX", "SDWl53Ozlv", "r84ZkGmF9s",
            "Af4RkD2A7x", "pnCfyf5V1i", "mPiaPECF84", "S61XugWTGj", "Xr3vDcZiSL",
            "hbe2ozJMbV", "ez3KV6txAw", "X40D3WbhxB", "Rl7avJiDvU", "kTkpl2wUcb",
            "AzmzlNmj2H", "I2DFYe3op8", "pB8x40Mx90", "at7peE0rZG", "KmmczW4tmZ",
            "VvH2qWcf3W", "Hqh0DO1Tfo", "rV9u4L5tle", "Q2Ubrg5Raq", "lp84dsFTAi",
            "mogja1neXG", "h54MhLeTfD", "b05DUZIhxA", "SOn0u9HjVX", "HkDQM5TG6y",
            "NH0Iy95p3I", "h1PzN3v9iF", "InWvY8toF6", "SBH6lFEGvU", "LEbAEue6mB"};

        public static User GetRandomUserModel(Random random)
        {
            string username = usernames[random.Next(0, usernames.Length)];
            string email = emails[random.Next(0, emails.Length)];
            string phone = phones[random.Next(0, phones.Length)];
            string password = passwords[random.Next(0, passwords.Length)];

            return new User(username, email, phone, password);
        }
    }
}
