using FlashCards.Api.Core.Denunciations;

namespace FlashCards.Api.Repository.Configs;

public class DenunciationConfig : IEntityTypeConfiguration<Denunciation>
{
    public void Configure(EntityTypeBuilder<Denunciation> builder)
    {
        builder
            .ToTable("denunciations");

        builder
            .HasKey(x => x.ID)
            .HasName("pk_denunciation_id");

        builder
            .Property(x => x.ID)
            .HasColumnName("denunciation_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.AccuserID)
            .HasColumnName("accuser_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.SuspectID)
            .HasColumnName("suspect_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("varchar")
            .HasMaxLength(Denunciation.TitleMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(Denunciation.DescriptionMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();

        builder
            .HasOne(x => x.Accuser)
            .WithMany()
            .HasForeignKey(x => x.AccuserID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Suspect)
            .WithMany()
            .HasForeignKey(x => x.SuspectID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
