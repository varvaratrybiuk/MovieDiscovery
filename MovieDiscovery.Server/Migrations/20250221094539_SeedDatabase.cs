using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDiscovery.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Фентезі" },
                    { 2, "Музичні" },
                    { 3, "Мелодрами" },
                    { 4, "Сімейний" },
                    { 5, "Дитячий" },
                    { 6, "Екшн" },
                    { 7, "Комедія" },
                    { 8, "Пригоди" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Ми переносимося в Країну Оз і знайомимося з відьмою на ім'я Ельфаба. Вона наділена не тільки надприродними здібностями, але й зеленим кольором шкіри. Через це з неї сміялися протягом усього дитинства, а тепер всі бояться Ельфаби. Відьма впевнена, що у світі немає жодної людини, якій варто було б довіряти. Життя головної героїні змінюється, коли вона опиняється в школі чаклунства. Тут Ельфаба знайомиться з Гліндою - чарівницею з добрим серцем, яка користується загальною любов'ю. Вона пропонує новенькій свою дружбу, що стає для всіх повною несподіванкою. В той самий час подруги дізнаються, що над їхнім світом нависла небезпека, яка походить від підступного чаклуна. Незважаючи на різні погляди, Ельфаба і Глінда об'єднують зусилля і вступають у боротьбу з темними силами.", 7.6f, "Чародійка", 2024 },
                    { 2, "Барбіленд – напрочуд прекрасний світ. Його мешканці – ідеальні та вічно молоді. Вони мають спортивні фігури, красиві обличчя. Постійно виглядаючи як супермоделі, хлопці та дівчата одягаються у модний одяг. Гучні вечірки супроводжуються виключно сучасною музикою, а їхні учасники здатні танцювати всю ніч. Але варто придивитися, видно, що рухи надто механічні, а прагнення до ідеалу надто наполегливе. Барбі з Кеном усіляко намагалися відповідати стандартам. Але їхні спроби були марними, що призвело до кризи. У новому світі вона зрозуміла, що зовсім необов'язково прагнути недосяжних ідеалів, що можна просто залишатися собою. З якими викликами доведеться зіткнутися білявій красуні і чи зможе вона знайти нових друзів?", 6.8f, "Барбі", 2023 },
                    { 3, "Мультфільм «Школа монстрів: 13 бажань» продовжує розповідати про дивовижні пригоди учнів найнезвичайнішої школи у світі. З початком нового навчального року юні монстри чекають на великі зміни у власних життях, адже новий рік обіцяє нові можливості. Деякі бажання учнів дуже прості, а деякі є практично нездійсненними. Так, юна Хоулін мріє стати найпопулярнішим дівчиськом у школі, але слава та популярність належить її старшій сестрі Клодін Вульф та її подругам. Однак після того, як в руки Хоулін потрапляє чарівна лампа з джином усередині, її мрія починає збуватися. Чарівний джин Джіджі дарує дівчинці можливість здійснити не одне, а цілих тринадцять бажань. Щоправда, невдовзі Хоулін розуміє, що свої бажання потрібно обирати дуже ретельно.", 6.9f, "Школа монстрів: 13 бажань", 2013 },
                    { 4, "Пригоди студентів незвичайного навчального закладу для монстрів продовжуються. Талановита співачка на ім'я Кетті Нуар залишила світ шоу-бізнесу в розпал своєї популярності. Дівчину залишило натхнення, тож вона не може писати нові пісні. Взявши паузу у творчій кар'єрі, вона вирішила присвятити більше часу навчанню. Одного дня разом зі своїми близькими приятельками, Нуар вирушає у величезне місто Бу-Йорк. Цей населений пункт є справжнім центром музики, моди та театрів. Саме тут збираються талановиті особи. Кетті сподівається зарядитись позитивною енергією від перебування в мегаполісі. Незабаром головних героїнь мультфільму «Школа Монстрів: Бу-Йорк, Бу-Йорк» чекають неймовірні зустрічі та пригоди.", 6.7f, "Школа монстрів: Бу Йорк, Бу Йорк", 2015 },
                    { 5, "Незвичайний анімаційний мультфільм Школа монстрів: Привиди показує життя учениць, які навчаються у школі для нечисті. На них чекають неймовірні пригоди в таємничому місці для привидів. Маленькі дівчатка-монстри разом із куратором відвідують світ Духів, хоч за правилами це заборонено. Директор - жінка, що дотримуються вкрай строгих правил. Головній героїні мультика Спектрі буде важко повернутись, оскільки керівниця навчального закладу не випустить її. Доводиться подругам дівчини бігти на допомогу. Що з цього вийде і чи пощастить повернути полонянку глядачі дізнаються, подивившись мультфільм.", 6.3f, "Школа монстрів: Привиди", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Movies_Genres",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 3, 2 },
                    { 5, 6, 2 },
                    { 6, 7, 2 },
                    { 7, 8, 2 },
                    { 8, 1, 3 },
                    { 9, 5, 3 },
                    { 10, 7, 3 },
                    { 11, 2, 4 },
                    { 12, 5, 4 },
                    { 13, 8, 4 },
                    { 14, 1, 5 },
                    { 15, 4, 5 },
                    { 16, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies_Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
