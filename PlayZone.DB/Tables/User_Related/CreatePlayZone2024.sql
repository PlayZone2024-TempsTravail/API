CREATE TABLE "Role" (
    "id_role"   SERIAL,
    "name"      VARCHAR(255),

    CONSTRAINT PK__Role PRIMARY KEY ("id_role"),

    CONSTRAINT U__Role__name UNIQUE ("name"),

    CONSTRAINT NN__Role__name CHECK ("name" IS NOT NULL)
);

CREATE TABLE "Role_Permission" (
    "role_id"           INT,
    "permission_id"     CHAR(255),

    CONSTRAINT PK_Role_Permission PRIMARY KEY ("role_id", "permission_id"),

    CONSTRAINT FK__Role_Permission__role_id FOREIGN KEY ("role_id") REFERENCES "Role"("id_role")
);

CREATE TABLE "User" (
    "id_user"                       SERIAL,
    "role_id"                       INT,
    "isActive"                      BOOLEAN DEFAULT true,
    "nom"                           VARCHAR(255),
    "prenom"                        VARCHAR(255),
    "email"                         VARCHAR(255),
    "password"                      VARCHAR(2000),
    "heures_annuelles_prestables"   INT,
    "VA"                            INT DEFAULT 0,
    "VAEX"                          INT DEFAULT 0,
    "RC"                            INT DEFAULT 0,

    CONSTRAINT PK__User PRIMARY KEY ("id_user"),

    CONSTRAINT U__User__email UNIQUE ("email"),

    CONSTRAINT NN__User__role_Id CHECK ("role_id" IS NOT NULL),
    CONSTRAINT NN__User__isActive CHECK ("isActive" IS NOT NULL),
    CONSTRAINT NN__User__nom CHECK ("nom" IS NOT NULL),
    CONSTRAINT NN__User__prenom CHECK ("prenom" IS NOT NULL),
    CONSTRAINT NN__User__email CHECK ("email" IS NOT NULL),
    CONSTRAINT NN__User__password CHECK ("password" IS NOT NULL),
    CONSTRAINT NN__User__VA CHECK ("VA" IS NOT NULL),
    CONSTRAINT NN__User__VAEX CHECK ("VAEX" IS NOT NULL),
    CONSTRAINT NN__User__RC CHECK ("RC" IS NOT NULL),

    CONSTRAINT FK__User__role_Id FOREIGN KEY ("role_id") REFERENCES "Role"("id_role")
);

CREATE TABLE "WorkTime_Category" (
    "id_workTime_category"  CHAR(4),
    "name"                  VARCHAR(255),

    CONSTRAINT PK__WorkTime_Category PRIMARY KEY ("id_workTime_category"),
    CONSTRAINT CK__WorkTime_Category__name CHECK ("name" IS NOT NULL)
);

CREATE TABLE "Project" (
    "id_project"                SERIAL,
    "name"                      VARCHAR(255),
    "montant_budget"            DECIMAL,
    "date_debut_projet"         TIMESTAMP,
    "date_debut_formation"      TIMESTAMP,
    "date_fin_projet"           TIMESTAMP,
    "charge_de_projet"          INT,

    CONSTRAINT PK__Project PRIMARY KEY ("id_project"),

    CONSTRAINT NN__Project__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__Project__date_debut_projet CHECK ("date_debut_projet" IS NOT NULL),
    CONSTRAINT NN__Project__date_debut_formation CHECK ("date_debut_formation" IS NOT NULL),
    CONSTRAINT NN__Project__date_fin_projet CHECK ("date_fin_projet" IS NOT NULL),
    CONSTRAINT NN__Project__charge_de_projet CHECK ("charge_de_projet" IS NOT NULL),

    CONSTRAINT FK__Project__charge_de_projet FOREIGN KEY ("charge_de_projet") REFERENCES "User"("id_user")
);

CREATE TABLE "WorkTime" (
    "id_WorkTime"     SERIAL,
    "start"           TIMESTAMP,
    "end"             TIMESTAMP,
    "category_id"     CHAR(4),
    "project_id"      INT,
    "user_id"         INT,

    CONSTRAINT PK__WorkTime PRIMARY KEY ("id_WorkTime"),

    CONSTRAINT NN__WorkTime__start CHECK ("start" IS NOT NULL),
    CONSTRAINT NN__WorkTime__end CHECK ("end" IS NOT NULL),
    CONSTRAINT NN__WorkTime__category_id CHECK ("category_id" IS NOT NULL),
    CONSTRAINT NN__WorkTime__user_id CHECK ("user_id" IS NOT NULL),

    CONSTRAINT FK__WorkTime__category_id FOREIGN KEY ("category_id") REFERENCES "WorkTime_Category"("id_workTime_category"),
    CONSTRAINT FK__WorkTime__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__WorkTime__user_id FOREIGN KEY ("user_id") REFERENCES "User"("id_user")
);

CREATE TABLE "Organisme" (
    "id_organisme"      SERIAL,
    "name"              VARCHAR(255),

    CONSTRAINT PK__Organisme__id_organisme PRIMARY KEY ("id_organisme"),

    CONSTRAINT NN__Organisme__name CHECK ("name" IS NOT NULL)
);

CREATE TABLE "SourceBudget" (
    "project_id"    INT,
    "organisme_id"  INT,
    "date"          TIMESTAMP,
    "montant"       INT,
    "facturation"   TIMESTAMP,

    CONSTRAINT PK__SourceBudget PRIMARY KEY ("project_id", "organisme_id"),

    CONSTRAINT NN__SourceBudget__date CHECK ("date" IS NOT NULL),
    CONSTRAINT NN__SourceBudget__montant CHECK ("montant" IS NOT NULL),

    CONSTRAINT FK__SourceBudget__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__SourceBudget__organisme_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Budget_Category" (
    "id_budget_category"    SERIAL,
    "name"                  VARCHAR(255),

    CONSTRAINT PK__Budget_Category PRIMARY KEY ("id_budget_category"),

    CONSTRAINT NN__Budget_Category__name CHECK ("name" IS NOT NULL)
);

CREATE TABLE "Budget_SousCategory" (
    "id_budget_sousCategory"    SERIAL,
    "libele"                    VARCHAR(255),
    "budget_category_id"        INT,

    CONSTRAINT PK__Budget_SousCategory PRIMARY KEY ("id_budget_sousCategory"),

    CONSTRAINT NN__Budget_SousCategory__libele CHECK ("libele" IS NOT NULL),
    CONSTRAINT NN__Budget_SousCategory__budget_categoryId CHECK ("budget_category_id" IS NOT NULL),

    CONSTRAINT FK__Budget_SousCategory__budget_categoryId FOREIGN KEY ("budget_category_id") REFERENCES "Budget_Category"("id_budget_category")
);

CREATE TABLE "Budget_Libele" (
    "id_budget_libele"  SERIAL,
    "name"              VARCHAR(255),
    "category_id"       INT,

    CONSTRAINT PK__Budget_Libele PRIMARY KEY ("id_budget_libele"),

    CONSTRAINT NN__budget_libele__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__budget_libele__category_id CHECK ("category_id" IS NOT NULL),

    CONSTRAINT FK__Budget_Libele__category_id FOREIGN KEY ("category_id") REFERENCES "Budget_Libele"("id_budget_libele")
);

CREATE TABLE "Budget_Prevision" (
    "id_budget_prevision"   SERIAL,
    "libele_id"             INT,
    "montant"               DECIMAL,
    "project_id"            INT,
    "date"                  TIMESTAMP,

    CONSTRAINT PK__Budget_Prevision PRIMARY KEY ("id_budget_prevision"),

    CONSTRAINT NN__Budget_Prevision__libele_id CHECK ("libele_id" IS NOT NULL),
    CONSTRAINT NN__Budget_Prevision__montant CHECK ("montant" IS NOT NULL),
    CONSTRAINT NN__Budget_Prevision__project_id CHECK ("project_id" IS NOT NULL),
    CONSTRAINT NN__Budget_Prevision__date CHECK ("date" IS NOT NULL),

    CONSTRAINT FK__Budget_Prevision__libele_id FOREIGN KEY ("libele_id") REFERENCES "Budget_Libele"("id_budget_libele"),
    CONSTRAINT FK__Budget_Prevision__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Cout_Reel" (
    "id_cout_reel"          SERIAL,
    "libele_id"             INT,
    "montant"               INT,
    "project_id"            INT,
    "date_intervention"     TIMESTAMP,
    "date_facturation"      TIMESTAMP,

    CONSTRAINT PK__Cout_Reel PRIMARY KEY ("id_cout_reel"),

    CONSTRAINT NN__Cout_Reel_libele_Id CHECK ("libele_id" IS NOT NULL),
    CONSTRAINT NN__Cout_Reel_montant CHECK ("montant" IS NOT NULL),
    CONSTRAINT NN__Cout_Reel_project_Id CHECK ("project_id" IS NOT NULL),
    CONSTRAINT NN__Cout_Reel_date_intervention CHECK ("date_intervention" IS NOT NULL),

    CONSTRAINT FK__Cout_Reel__libele_id FOREIGN KEY ("libele_id") REFERENCES "Budget_Libele"("id_budget_libele"),
    CONSTRAINT FK__Cout_Reel__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Budget_Category_Budget" (
    "project_id"                INT,
    "category_id"               INT,
    "montant_debut_formation"   INT,
    "montant_fin_projet"        INT,

    CONSTRAINT PK__Budget_Category_Budget PRIMARY KEY ("project_id", "category_id"),

    CONSTRAINT NN__Budget_Category_Budget__montant_debut_formationd CHECK ("montant_debut_formation" IS NOT NULL),
    CONSTRAINT NN__Budget_Category_Budget__montant_fin_projet CHECK ("montant_fin_projet" IS NOT NULL),

    CONSTRAINT FK__Budget_Category_Budget__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__Budget_Category_Budget__category_id FOREIGN KEY ("category_id") REFERENCES "Budget_Category"("id_budget_category")
);

CREATE TABLE "Budget_SousCategory_Budget" (
    "project_id"                INT,
    "sousCategory_id"           INT,
    "montant_debut_formation"   INT,
    "montant_fin_projet"        INT,

    CONSTRAINT PK__Budget_Category_Budget__Budget PRIMARY KEY ("project_id", "sousCategory_id"),

    CONSTRAINT NN__Budget_SousCategory_Budget__montant_debut_formation CHECK ("montant_debut_formation" IS NOT NULL),
    CONSTRAINT NN__Budget_SousCategory_Budget__montant_fin_projet CHECK ("montant_fin_projet" IS NOT NULL),

    CONSTRAINT FK__Budget_SousCategory_Budget__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__Budget_SousCategory_Budget__category_id FOREIGN KEY ("sousCategory_id") REFERENCES "Budget_Category"("id_budget_category")
);

CREATE TABLE "Configuration" (
    "id_configuration"  SERIAL,
    "date"              TIMESTAMP,
    "parameter_name"    VARCHAR(255),
    "parameter_value"   VARCHAR(255),

    CONSTRAINT PK__Configuration PRIMARY KEY ("id_configuration"),

    CONSTRAINT NN__Configuration__date CHECK ("date" IS NOT NULL),
    CONSTRAINT NN__Configuration__parameter_name CHECK ("parameter_name" IS NOT NULL),
    CONSTRAINT NN__Configuration__parameter_value CHECK ("parameter_value" IS NOT NULL)
);
