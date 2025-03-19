using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDiscovery.Server.Migrations
{
    /// <inheritdoc />
    public partial class SetNullOnUserDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Users_UserId",
                table: "Movies_Genres");

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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Ми переносимося в Країну Оз і знайомимося з відьмою...");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Барбіленд – напрочуд прекрасний світ...");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Мультфільм «Школа монстрів: 13 бажань» продовжує розповідати...");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Пригоди студентів незвичайного навчального закладу...");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Незвичайний анімаційний мультфільм Школа монстрів: Привиди...");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Users_UserId",
                table: "Movies_Genres",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Users_UserId",
                table: "Movies_Genres");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Ми переносимося в Країну Оз і знайомимося з відьмою на ім'я Ельфаба. Вона наділена не тільки надприродними здібностями, але й зеленим кольором шкіри. Через це з неї сміялися протягом усього дитинства, а тепер всі бояться Ельфаби. Відьма впевнена, що у світі немає жодної людини, якій варто було б довіряти. Життя головної героїні змінюється, коли вона опиняється в школі чаклунства. Тут Ельфаба знайомиться з Гліндою - чарівницею з добрим серцем, яка користується загальною любов'ю. Вона пропонує новенькій свою дружбу, що стає для всіх повною несподіванкою. В той самий час подруги дізнаються, що над їхнім світом нависла небезпека, яка походить від підступного чаклуна. Незважаючи на різні погляди, Ельфаба і Глінда об'єднують зусилля і вступають у боротьбу з темними силами.");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Барбіленд – напрочуд прекрасний світ. Його мешканці – ідеальні та вічно молоді. Вони мають спортивні фігури, красиві обличчя. Постійно виглядаючи як супермоделі, хлопці та дівчата одягаються у модний одяг. Гучні вечірки супроводжуються виключно сучасною музикою, а їхні учасники здатні танцювати всю ніч. Але варто придивитися, видно, що рухи надто механічні, а прагнення до ідеалу надто наполегливе. Барбі з Кеном усіляко намагалися відповідати стандартам. Але їхні спроби були марними, що призвело до кризи. У новому світі вона зрозуміла, що зовсім необов'язково прагнути недосяжних ідеалів, що можна просто залишатися собою. З якими викликами доведеться зіткнутися білявій красуні і чи зможе вона знайти нових друзів?");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Мультфільм «Школа монстрів: 13 бажань» продовжує розповідати про дивовижні пригоди учнів найнезвичайнішої школи у світі. З початком нового навчального року юні монстри чекають на великі зміни у власних життях, адже новий рік обіцяє нові можливості. Деякі бажання учнів дуже прості, а деякі є практично нездійсненними. Так, юна Хоулін мріє стати найпопулярнішим дівчиськом у школі, але слава та популярність належить її старшій сестрі Клодін Вульф та її подругам. Однак після того, як в руки Хоулін потрапляє чарівна лампа з джином усередині, її мрія починає збуватися. Чарівний джин Джіджі дарує дівчинці можливість здійснити не одне, а цілих тринадцять бажань. Щоправда, невдовзі Хоулін розуміє, що свої бажання потрібно обирати дуже ретельно.");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Пригоди студентів незвичайного навчального закладу для монстрів продовжуються. Талановита співачка на ім'я Кетті Нуар залишила світ шоу-бізнесу в розпал своєї популярності. Дівчину залишило натхнення, тож вона не може писати нові пісні. Взявши паузу у творчій кар'єрі, вона вирішила присвятити більше часу навчанню. Одного дня разом зі своїми близькими приятельками, Нуар вирушає у величезне місто Бу-Йорк. Цей населений пункт є справжнім центром музики, моди та театрів. Саме тут збираються талановиті особи. Кетті сподівається зарядитись позитивною енергією від перебування в мегаполісі. Незабаром головних героїнь мультфільму «Школа Монстрів: Бу-Йорк, Бу-Йорк» чекають неймовірні зустрічі та пригоди.");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Незвичайний анімаційний мультфільм Школа монстрів: Привиди показує життя учениць, які навчаються у школі для нечисті. На них чекають неймовірні пригоди в таємничому місці для привидів. Маленькі дівчатка-монстри разом із куратором відвідують світ Духів, хоч за правилами це заборонено. Директор - жінка, що дотримуються вкрай строгих правил. Головній героїні мультика Спектрі буде важко повернутись, оскільки керівниця навчального закладу не випустить її. Доводиться подругам дівчини бігти на допомогу. Що з цього вийде і чи пощастить повернути полонянку глядачі дізнаються, подивившись мультфільм.");

            migrationBuilder.InsertData(
                table: "Movies_Genres",
                columns: new[] { "Id", "GenreId", "MovieId", "UserId" },
                values: new object[,]
                {
                    { 13, 8, 4, null },
                    { 14, 1, 5, null },
                    { 15, 4, 5, null },
                    { 16, 5, 5, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Users_UserId",
                table: "Movies_Genres",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
