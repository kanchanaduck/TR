﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_hrgis.Data;

namespace api_hrgis.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api_hrgis.Models.tb_band", b =>
                {
                    b.Property<string>("band")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("status_active")
                        .HasColumnType("bit");

                    b.HasKey("band");

                    b.ToTable("tb_band");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_employee", b =>
                {
                    b.Property<string>("emp_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("band")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("dept_abb_name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("dept_code")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("dept_name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("div_abb_name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("div_cls")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("div_name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("fname_eng")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("fname_tha")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("gname_eng")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("gname_tha")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("old_emp_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("posn_code")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("posn_ename")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("prob_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("resn_date")
                        .HasColumnType("date");

                    b.Property<string>("sname_eng")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("sname_tha")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("wc_abb_name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("wc_code")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("wc_name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("emp_no");

                    b.ToTable("tb_employee");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_employee_role_claims", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tb_employee_role_claims");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_menus", b =>
                {
                    b.Property<int>("menu_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("menu_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("parent_menu_code")
                        .HasColumnType("int");

                    b.Property<string>("spare1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("menu_code");

                    b.HasIndex("parent_menu_code");

                    b.ToTable("tb_menus");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_organization", b =>
                {
                    b.Property<string>("org_code")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Center (1) > Division (2) > Department(3) > Work center(4)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("level_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("level_seq")
                        .HasColumnType("int");

                    b.Property<string>("org_abb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("org_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parent_org_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("spare1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("org_code");

                    b.HasIndex("parent_org_code");

                    b.ToTable("tb_organization");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_role", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("tb_role");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_role_menu_claims", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("menu_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<string>("spare1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spare4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tb_role_menu_claims");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool?>("emailconfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("passwordhash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("phonenumberconfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("storedsalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_center", b =>
                {
                    b.Property<string>("emp_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("emp_no");

                    b.ToTable("tr_center");

                    b
                        .HasComment("ตารางเก็บข้อมูลcenter");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course", b =>
                {
                    b.Property<string>("course_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<string>("course_name_en")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name_th")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_end")
                        .HasColumnType("date");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("date");

                    b.Property<int>("days")
                        .HasColumnType("int");

                    b.Property<string>("dept_abb_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("open_register")
                        .HasColumnType("bit");

                    b.Property<string>("place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("status_active")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("time_in")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("time_out")
                        .HasColumnType("time");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("course_no");

                    b.ToTable("tr_course");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_band", b =>
                {
                    b.Property<string>("course_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("band")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("course_no", "band");

                    b.HasIndex("band");

                    b.ToTable("tr_course_band");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_master", b =>
                {
                    b.Property<string>("course_no")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name_en")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name_th")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("days")
                        .HasColumnType("int");

                    b.Property<string>("dept_abb_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prev_course_no")
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool?>("status_active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("course_no");

                    b.HasIndex("prev_course_no");

                    b.ToTable("tr_course_master");

                    b
                        .HasComment("ตารางเก็บข้อมูลคอร์ส 6 หลัก เพื่อช่วยในการเปิดคอร์ส");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_master_band", b =>
                {
                    b.Property<string>("course_no")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("band")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("course_no", "band");

                    b.HasIndex("band");

                    b.ToTable("tr_course_master_band");

                    b
                        .HasComment("ตารางจับคู่คอร์สมาสเตอร์และแบนด์");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_registration", b =>
                {
                    b.Property<string>("course_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("emp_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("center_approved_at")
                        .HasColumnType("datetime");

                    b.Property<string>("center_approved_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("center_approved_checked")
                        .HasColumnType("bit");

                    b.Property<string>("last_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("manager_approved_at")
                        .HasColumnType("datetime");

                    b.Property<string>("manager_approved_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("manager_approved_checked")
                        .HasColumnType("bit");

                    b.Property<string>("post_test_grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("post_test_score")
                        .HasColumnType("int");

                    b.Property<string>("pre_test_grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("pre_test_score")
                        .HasColumnType("int");

                    b.Property<DateTime?>("register_at")
                        .HasColumnType("datetime");

                    b.Property<string>("register_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("scored_at")
                        .HasColumnType("datetime");

                    b.Property<string>("scored_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seq_no")
                        .HasColumnType("int");

                    b.HasKey("course_no", "emp_no");

                    b.HasIndex("emp_no");

                    b.ToTable("tr_course_registration");

                    b
                        .HasComment("เปิ้ลอธิบายตารางนี้ให้ฟังหน่อย");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_trainer", b =>
                {
                    b.Property<string>("course_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("trainer_no")
                        .HasColumnType("int");

                    b.HasKey("course_no", "trainer_no");

                    b.HasIndex("trainer_no");

                    b.ToTable("tr_course_trainer");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_stakeholder", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_no")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("org_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("emp_no");

                    b.HasIndex("org_code");

                    b.ToTable("tr_stakeholder");

                    b
                        .HasComment("ตารางเก็บข้อมูลผู้ที่เกี่ยวข้อง");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_survey_detail", b =>
                {
                    b.Property<string>("course_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("เลขคอร์ส 6 หลัก");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("month")
                        .HasColumnType("int")
                        .HasComment("เก็บเดือนที่ต้องการเรียน");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("year")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("year");

                    b.ToTable("tr_survey_detail");

                    b
                        .HasComment("ตารางเก็บข้อมูลการ survey");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_survey_file", b =>
                {
                    b.Property<int>("file_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("approved")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Level");

                    b.Property<string>("organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("เก็บ division หรือ department ที่ committee คนนั้นรับผิดชอบ");

                    b.Property<string>("year")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("year");

                    b.HasKey("file_id");

                    b.ToTable("tr_survey_file");

                    b
                        .HasComment("ตารางเก็บไฟล์ในการ survey");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_survey_setting", b =>
                {
                    b.Property<string>("year")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_end")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("year");

                    b.ToTable("tr_survey_setting");

                    b
                        .HasComment("ตารางเก็บ period การ survey เฉพาะคอร์สของ MTP");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_trainer", b =>
                {
                    b.Property<int>("trainer_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_no")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("fname_en")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fname_th")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gname_en")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gname_th")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sname_en")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sname_th")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("status_active")
                        .HasColumnType("bit");

                    b.Property<string>("trainer_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trainer_no");

                    b.ToTable("tr_trainer");

                    b
                        .HasComment("ตารางเก็บข้อมูลเทรนเนอร์");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_menus", b =>
                {
                    b.HasOne("api_hrgis.Models.tb_menus", "parent")
                        .WithMany("children")
                        .HasForeignKey("parent_menu_code");

                    b.Navigation("parent");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_organization", b =>
                {
                    b.HasOne("api_hrgis.Models.tb_organization", "parent_org")
                        .WithMany("children_org")
                        .HasForeignKey("parent_org_code");

                    b.Navigation("parent_org");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_band", b =>
                {
                    b.HasOne("api_hrgis.Models.tb_band", "bands")
                        .WithMany("courses_bands")
                        .HasForeignKey("band")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_hrgis.Models.tr_course", "courses")
                        .WithMany("courses_bands")
                        .HasForeignKey("course_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bands");

                    b.Navigation("courses");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_master", b =>
                {
                    b.HasOne("api_hrgis.Models.tr_course_master", "prev_course")
                        .WithMany("next_course")
                        .HasForeignKey("prev_course_no");

                    b.Navigation("prev_course");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_master_band", b =>
                {
                    b.HasOne("api_hrgis.Models.tb_band", "bands")
                        .WithMany("course_masters_bands")
                        .HasForeignKey("band")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_hrgis.Models.tr_course_master", "course_masters")
                        .WithMany("course_masters_bands")
                        .HasForeignKey("course_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bands");

                    b.Navigation("course_masters");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_registration", b =>
                {
                    b.HasOne("api_hrgis.Models.tr_course", "courses")
                        .WithMany("courses_registrations")
                        .HasForeignKey("course_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_hrgis.Models.tb_employee", "employees")
                        .WithMany("courses_registrations")
                        .HasForeignKey("emp_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_trainer", b =>
                {
                    b.HasOne("api_hrgis.Models.tr_course", "courses")
                        .WithMany("courses_trainers")
                        .HasForeignKey("course_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_hrgis.Models.tr_trainer", "trainers")
                        .WithMany("courses_trainers")
                        .HasForeignKey("trainer_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("trainers");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_stakeholder", b =>
                {
                    b.HasOne("api_hrgis.Models.tb_employee", "employee")
                        .WithMany("stakeholders")
                        .HasForeignKey("emp_no");

                    b.HasOne("api_hrgis.Models.tb_organization", "organization")
                        .WithMany("stakeholders")
                        .HasForeignKey("org_code");

                    b.Navigation("employee");

                    b.Navigation("organization");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_band", b =>
                {
                    b.Navigation("course_masters_bands");

                    b.Navigation("courses_bands");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_employee", b =>
                {
                    b.Navigation("courses_registrations");

                    b.Navigation("stakeholders");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_menus", b =>
                {
                    b.Navigation("children");
                });

            modelBuilder.Entity("api_hrgis.Models.tb_organization", b =>
                {
                    b.Navigation("children_org");

                    b.Navigation("stakeholders");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course", b =>
                {
                    b.Navigation("courses_bands");

                    b.Navigation("courses_registrations");

                    b.Navigation("courses_trainers");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_course_master", b =>
                {
                    b.Navigation("course_masters_bands");

                    b.Navigation("next_course");
                });

            modelBuilder.Entity("api_hrgis.Models.tr_trainer", b =>
                {
                    b.Navigation("courses_trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
