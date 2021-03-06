// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatsTheWeatherDatabaseAccess;

#nullable disable

namespace WhatsTheWeather.Migrations
{
    [DbContext(typeof(StatisticsDbContext))]
    [Migration("20220529201041_FixedCoordsIntToFloat")]
    partial class FixedCoordsIntToFloat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WhatsTheWeatherDatabaseAccess.DbModels.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<int>("CoordsId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CoordsId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("WhatsTheWeatherDatabaseAccess.DbModels.Coords", b =>
                {
                    b.Property<int>("CoordsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoordsId"), 1L, 1);

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("CoordsId");

                    b.ToTable("Coords");
                });

            modelBuilder.Entity("WhatsTheWeatherDatabaseAccess.DbModels.LocationVisits", b =>
                {
                    b.Property<int>("LocationVisitsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationVisitsId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("VisitsCounter")
                        .HasColumnType("int");

                    b.HasKey("LocationVisitsId");

                    b.HasIndex("CityId");

                    b.ToTable("LocationVisits");
                });

            modelBuilder.Entity("WhatsTheWeatherDatabaseAccess.DbModels.City", b =>
                {
                    b.HasOne("WhatsTheWeatherDatabaseAccess.DbModels.Coords", "Coords")
                        .WithMany()
                        .HasForeignKey("CoordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coords");
                });

            modelBuilder.Entity("WhatsTheWeatherDatabaseAccess.DbModels.LocationVisits", b =>
                {
                    b.HasOne("WhatsTheWeatherDatabaseAccess.DbModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
