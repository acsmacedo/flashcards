using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -8);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -7);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -6);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -5);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -4);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -3);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "categories",
            //    keyColumn: "category_id",
            //    keyValue: -1);

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "account_id", "email", "password", "Status" },
                values: new object[,]
                {
                    { -10, "teste@flashcard.com.br", "123456", 0 },
                    { -9, "bruno@flashcard.com.br", "23011993", 0 },
                    { -8, "otavio@flashcard.com.br", "23011993", 0 },
                    { -7, "fernanda@flashcard.com.br", "23011993", 0 },
                    { -6, "patricia@flashcard.com.br", "23011993", 0 },
                    { -5, "ana@flashcard.com.br", "23011993", 0 },
                    { -4, "paulo@flashcard.com.br", "23011993", 0 },
                    { -3, "gustavo@flashcard.com.br", "23011993", 0 },
                    { -2, "maria@flashcard.com.br", "23011993", 0 },
                    { -1, "anderson@flashcard.com.br", "23011993", 0 }
                });

            migrationBuilder.InsertData(
                table: "notification_settings",
                columns: new[] { "notification_setting_id", "description", "name" },
                values: new object[,]
                {
                    { -5, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Avaliações e comentários" },
                    { -4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Sugestões de conteúdo" },
                    { -3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Atualizações de conteúdo" },
                    { -2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Novo seguidor" },
                    { -1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Promoções e novidades" }
                });

            migrationBuilder.InsertData(
                table: "subscription_types",
                columns: new[] { "subscription_type_id", "name", "price" },
                values: new object[,]
                {
                    { -3, "Plano Premium", 29.99m },
                    { -2, "Plano Essencial", 9.99m },
                    { -1, "Plano Free", null }
                });

            migrationBuilder.InsertData(
                table: "subscription_type_benefits",
                columns: new[] { "subscription_type_benefit_id", "benefit", "subscription_type_id" },
                values: new object[,]
                {
                    { -13, "Lorem ipsum is simply dummy", -3 },
                    { -12, "Lorem ipsum is simply dummy", -3 },
                    { -11, "Lorem ipsum is simply dummy", -3 },
                    { -10, "Lorem ipsum is simply dummy", -3 },
                    { -9, "Lorem ipsum is simply dummy", -3 },
                    { -8, "Lorem ipsum is simply dummy", -3 },
                    { -7, "Lorem ipsum is simply dummy", -2 },
                    { -6, "Lorem ipsum is simply dummy", -2 },
                    { -5, "Lorem ipsum is simply dummy", -2 },
                    { -4, "Lorem ipsum is simply dummy", -2 },
                    { -3, "Lorem ipsum is simply dummy", -1 },
                    { -2, "Lorem ipsum is simply dummy", -1 },
                    { -1, "Lorem ipsum is simply dummy", -1 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "account_id", "instagram", "interests", "name", "photo", "SubscriptionTypeID" },
                values: new object[,]
                {
                    { -10, -10, null, null, "Usuário Teste", null, null },
                    { -9, -9, null, null, "Bruno Gomes", null, null },
                    { -8, -8, null, null, "Otávio Santos", null, null },
                    { -7, -7, null, null, "Fernanda Albuquerque", null, null },
                    { -6, -6, null, null, "Patrícia Castro", null, null },
                    { -5, -5, null, null, "Ana Ferreira", null, null },
                    { -4, -4, null, null, "Paulo Pereira", null, null },
                    { -3, -3, null, null, "Gustavo Oliveira", null, null },
                    { -2, -2, null, null, "Maria Souza", null, null },
                    { -1, -1, null, null, "Anderson Macedo", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "notification_settings",
                keyColumn: "notification_setting_id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "notification_settings",
                keyColumn: "notification_setting_id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "notification_settings",
                keyColumn: "notification_setting_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "notification_settings",
                keyColumn: "notification_setting_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "notification_settings",
                keyColumn: "notification_setting_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "subscription_type_benefits",
                keyColumn: "subscription_type_benefit_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "subscription_types",
                keyColumn: "subscription_type_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "subscription_types",
                keyColumn: "subscription_type_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "subscription_types",
                keyColumn: "subscription_type_id",
                keyValue: -1);

            //migrationBuilder.InsertData(
            //    table: "categories",
            //    columns: new[] { "category_id", "image", "name" },
            //    values: new object[,]
            //    {
            //        { -8, "http://acsmacedo.somee.com/images/categories/categoria_saude.png", "Saúde" },
            //        { -7, "http://acsmacedo.somee.com/images/categories/categoria_programacao.png", "Programação" },
            //        { -6, "http://acsmacedo.somee.com/images/categories/categoria_literatura.png", "Literatura" },
            //        { -5, "http://acsmacedo.somee.com/images/categories/categoria_geografia.png", "Geografia" },
            //        { -4, "http://acsmacedo.somee.com/images/categories/categoria_financas.png", "Finanças" },
            //        { -3, "http://acsmacedo.somee.com/images/categories/categoria_design.png", "Design" },
            //        { -2, "http://acsmacedo.somee.com/images/categories/categoria_arquitetura.png", "Arquitetura" },
            //        { -1, "http://acsmacedo.somee.com/images/categories/categoria_administracao.png", "Administração" }
            //    });
        }
    }
}
