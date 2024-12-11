CREATE TABLE "Configuration" (
    "id_configuration"  INT GENERATED BY DEFAULT AS IDENTITY,
    "date"              TIMESTAMP DEFAULT NOW(),
    "parameter_name"    VARCHAR(255),
    "parameter_value"   VARCHAR(255),

    CONSTRAINT PK__Configuration PRIMARY KEY ("id_configuration"),

    CONSTRAINT NN__Configuration__date CHECK ("date" IS NOT NULL),
    CONSTRAINT NN__Configuration__parameter_name CHECK ("parameter_name" IS NOT NULL),
    CONSTRAINT NN__Configuration__parameter_value CHECK ("parameter_value" IS NOT NULL)
);

CREATE TABLE "Role" (
    "id_role"       INT GENERATED BY DEFAULT AS IDENTITY,
    "name"          VARCHAR(255),
    "isRemovable"   BOOLEAN DEFAULT TRUE,
    "isVisible"     BOOLEAN DEFAULT TRUE,

    CONSTRAINT PK__Role PRIMARY KEY ("id_role"),

    CONSTRAINT U__Role__name UNIQUE ("name"),

    CONSTRAINT NN__Role__name CHECK ("name" IS NOT NULL)
);

CREATE TABLE "Role_Permission" (
    "role_id"           INT,
    "permission_id"     VARCHAR(255),

    CONSTRAINT PK_Role_Permission PRIMARY KEY ("role_id", "permission_id"),

    CONSTRAINT FK__Role_Permission__role_id FOREIGN KEY ("role_id") REFERENCES "Role"("id_role")
);

CREATE TABLE "User" (
    "id_user"                       INT GENERATED BY DEFAULT AS IDENTITY,
    "isActive"                      BOOLEAN DEFAULT true,
    "nom"                           VARCHAR(255),
    "prenom"                        VARCHAR(255),
    "email"                         VARCHAR(255),
    "password"                      VARCHAR(255),

    CONSTRAINT PK__User PRIMARY KEY ("id_user"),

    CONSTRAINT U__User__email UNIQUE ("email"),

    CONSTRAINT NN__User__isActive CHECK ("isActive" IS NOT NULL),
    CONSTRAINT NN__User__nom CHECK ("nom" IS NOT NULL),
    CONSTRAINT NN__User__prenom CHECK ("prenom" IS NOT NULL),
    CONSTRAINT NN__User__email CHECK ("email" IS NOT NULL)
);

CREATE TABLE "User_Role" (
    "user_id"   INT,
    "role_id"   INT,

    CONSTRAINT PK__User_Role PRIMARY KEY ("user_id", "role_id"),

    CONSTRAINT FK__User_Role__user_id FOREIGN KEY ("user_id") REFERENCES "User"("id_user"),
    CONSTRAINT FK__User_Role__role_id FOREIGN KEY ("role_id") REFERENCES "Role"("id_role")
);

CREATE TABLE "UserSalaire" (
    "id_userSalaire"    INT GENERATED BY DEFAULT AS IDENTITY,
    "user_id"           INT,
    "date"              TIMESTAMP,
    "regime"            INT,
    "montant"           DECIMAL,

    CONSTRAINT PK__UserSalaire PRIMARY KEY ("id_userSalaire"),

    CONSTRAINT NN__UserSalaire__user_id CHECK ("user_id" IS NOT NULL),
    CONSTRAINT NN__UserSalaire__date CHECK ("date" IS NOT NULL),
    CONSTRAINT NN__UserSalaire__regime CHECK ("regime" IS NOT NULL),
    CONSTRAINT NN__UserSalaire__montant CHECK ("montant" IS NOT NULL),

    CONSTRAINT FK__UserSalaire__user_id FOREIGN KEY ("user_id") REFERENCES "User"("id_user")
);

CREATE TABLE "WorkTime_Category" (
    "id_workTime_category"  INT GENERATED BY DEFAULT AS IDENTITY,
    "isActive"              BOOLEAN DEFAULT TRUE,
    "abreviation"           VARCHAR(5),
    "name"                  VARCHAR(255),
    "color"                 VARCHAR(8),

    CONSTRAINT PK__WorkTime_Category PRIMARY KEY ("id_workTime_category"),

    CONSTRAINT NN__WorkTime_Category__isActive CHECK ("isActive" IS NOT NULL),
    CONSTRAINT NN__WorkTime_Category__abreviation CHECK ("abreviation" IS NOT NULL),
    CONSTRAINT NN__WorkTime_Category__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__WorkTime_Category__color CHECK ("color" IS NOT NULL)
);

CREATE TABLE "Compteur_WorkTime_Category" (
    "user_id"               INT,
    "workTime_category_id"  INT,
    "quantity"              INT DEFAULT 0,

    CONSTRAINT PK__Compteur_WorkTime_Category PRIMARY KEY ("user_id", "workTime_category_id"),

    CONSTRAINT NN__WorkTime_Category__quantity CHECK ("quantity" IS NOT NULL),
    CONSTRAINT CK__WorkTime_Category__quantity CHECK ("quantity" >= 0),

    CONSTRAINT FK__WorkTime_Category__user_id FOREIGN KEY ("user_id") REFERENCES "User"("id_user"),
    CONSTRAINT FK__WorkTime_Category__workTime_category_id FOREIGN KEY ("workTime_category_id") REFERENCES "WorkTime_Category"("id_workTime_category")
);

CREATE TABLE "Project" (
    "id_project"                INT GENERATED BY DEFAULT AS IDENTITY,
    "organisme_id"              INT,
    "isActive"                  BOOLEAN DEFAULT TRUE,
    "name"                      VARCHAR(255),
    "montant_budget"            DECIMAL,
    "color"                     VARCHAR(8),
    "date_debut_projet"         TIMESTAMP,
    "date_fin_projet"           TIMESTAMP,
    "charge_de_projet"          INT,

    CONSTRAINT PK__Project PRIMARY KEY ("id_project"),

    CONSTRAINT NN__Project__organisme_id CHECK ("organisme_id" IS NOT NULL),
    CONSTRAINT NN__Project__isActive CHECK ("isActive" IS NOT NULL),
    CONSTRAINT NN__Project__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__Project__color CHECK ("color" IS NOT NULL),
    CONSTRAINT NN__Project__date_debut_projet CHECK ("date_debut_projet" IS NOT NULL),
    CONSTRAINT NN__Project__date_fin_projet CHECK ("date_fin_projet" IS NOT NULL),
    CONSTRAINT NN__Project__charge_de_projet CHECK ("charge_de_projet" IS NOT NULL),

    CONSTRAINT FK__Project__charge_de_projet FOREIGN KEY ("charge_de_projet") REFERENCES "User"("id_user")
);

CREATE TABLE "WorkTime" (
    "id_WorkTime"       INT GENERATED BY DEFAULT AS IDENTITY,
    "start"             TIMESTAMP,
    "end"               TIMESTAMP,
    "isOnSite"          BOOLEAN DEFAULT TRUE,
    "category_id"       INT,
    "project_id"        INT,
    "user_id"           INT,

    CONSTRAINT PK__WorkTime PRIMARY KEY ("id_WorkTime"),

    CONSTRAINT NN__WorkTime__start CHECK ("start" IS NOT NULL),
    CONSTRAINT NN__WorkTime__end CHECK ("end" IS NOT NULL),
    CONSTRAINT NN__WorkTime__isOnSite CHECK ("isOnSite" IS NOT NULL),
    CONSTRAINT NN__WorkTime__category_id CHECK ("category_id" IS NOT NULL),
    CONSTRAINT NN__WorkTime__user_id CHECK ("user_id" IS NOT NULL),

    CONSTRAINT FK__WorkTime__category_id FOREIGN KEY ("category_id") REFERENCES "WorkTime_Category"("id_workTime_category"),
    CONSTRAINT FK__WorkTime__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__WorkTime__user_id FOREIGN KEY ("user_id") REFERENCES "User"("id_user")
);

CREATE TABLE "Organisme" (
    "id_organisme"      INT GENERATED BY DEFAULT AS IDENTITY,
    "name"              VARCHAR(255),

    CONSTRAINT PK__Organisme__id_organisme PRIMARY KEY ("id_organisme"),

    CONSTRAINT NN__Organisme__name CHECK ("name" IS NOT NULL),
    CONSTRAINT U__Organisme__name UNIQUE ("name")
);

CREATE TABLE "Category" (
    "id_category"               INT GENERATED BY DEFAULT AS IDENTITY,
    "name"                      VARCHAR(255),
    "isIncome"                  BOOLEAN DEFAULT FALSE,
    "EstimationParCategorie"    BOOLEAN DEFAULT TRUE,

    CONSTRAINT PK__Category PRIMARY KEY ("id_category"),

    CONSTRAINT NN__libele__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__libele__isIncome CHECK ("isIncome" IS NOT NULL),
    CONSTRAINT NN__libele__EstimationParCategorie CHECK ("EstimationParCategorie" IS NOT NULL)
);

CREATE TABLE "Libele" (
    "id_libele"     INT GENERATED BY DEFAULT AS IDENTITY,
    "category_id"   INT,
    "name"          VARCHAR(255),

    CONSTRAINT PK__Libele PRIMARY KEY ("id_libele"),

    CONSTRAINT NN__libele__name CHECK ("name" IS NOT NULL),
    CONSTRAINT NN__libele__category_id CHECK ("category_id" IS NOT NULL),

    CONSTRAINT FK__Libele__category_id FOREIGN KEY ("category_id") REFERENCES "Category"("id_category")
);



CREATE TABLE "Prevision_Budget_Category" (
    "id_prevision_budget_category"  INT GENERATED BY DEFAULT AS IDENTITY,
    "project_id"                    INT,
    "category_id"                   INT,
    "date"                          TIMESTAMP,
    "motif"                         VARCHAR(255),
    "montant"                       DECIMAL,

    CONSTRAINT PK__Prevision_Budget_Category PRIMARY KEY ("id_prevision_budget_category"),
    CONSTRAINT U__Prevision_Budget_Category UNIQUE ("project_id", "category_id", "date"),

    CONSTRAINT NN__libele__motif CHECK ("motif" IS NOT NULL),
    CONSTRAINT NN__libele__montant CHECK ("montant" IS NOT NULL),

    CONSTRAINT FK__Prevision_Budget_Category__category_id FOREIGN KEY ("category_id") REFERENCES "Category"("id_category"),
    CONSTRAINT FK__Prevision_Budget_Category__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Prevision_Budget_Libele" (
    "id_prevision_budget_libele"    INT GENERATED BY DEFAULT AS IDENTITY,
    "project_id"                    INT,
    "libele_id"                     INT,
    "date"                          TIMESTAMP,
    "motif"                         VARCHAR(255),
    "montant"                       DECIMAL,


    CONSTRAINT PK__Prevision_Budget_Libele PRIMARY KEY ("id_prevision_budget_libele"),
    CONSTRAINT U__Prevision_Budget_Libele UNIQUE ("project_id", "libele_id", "date"),

    CONSTRAINT NN__libele__montant CHECK ("montant" IS NOT NULL),

    CONSTRAINT FK__Prevision_Budget_Libele__libele_id FOREIGN KEY ("libele_id") REFERENCES "Libele"("id_libele"),
    CONSTRAINT FK__Prevision_Budget_Libele__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Depense" (
    "id_depense"            INT GENERATED BY DEFAULT AS IDENTITY,
    "libele_id"             INT,
    "project_id"            INT,
    "organisme_id"          INT,
    "montant"               DECIMAL,
    "date_intervention"     TIMESTAMP,
    "date_facturation"      TIMESTAMP,
    "motif"                 VARCHAR(255),

    CONSTRAINT PK__Depense PRIMARY KEY ("id_depense"),

    CONSTRAINT NN__Depense__libele_id CHECK ("libele_id" IS NOT NULL),
    CONSTRAINT NN__Depense__project_id CHECK ("project_id" IS NOT NULL),
    CONSTRAINT NN__Depense__montant CHECK ("montant" IS NOT NULL),
    CONSTRAINT NN__Depense__date_facturation CHECK ("date_facturation" IS NOT NULL),

    CONSTRAINT FK__Depense__libele_id FOREIGN KEY ("libele_id") REFERENCES "Libele"("id_libele"),
    CONSTRAINT FK__Depense__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project")
);

CREATE TABLE "Rentree" (
    "id_rentree"            INT GENERATED BY DEFAULT AS IDENTITY,
    "libele_id"             INT,
    "project_id"            INT,
    "organisme_id"          INT,
    "montant"               DECIMAL,
    "date_facturation"      TIMESTAMP,
    "motif"                 VARCHAR(255),

    CONSTRAINT PK__Rentree PRIMARY KEY ("id_rentree"),

    CONSTRAINT NN__Rentree__libele_id CHECK ("libele_id" IS NOT NULL),
    CONSTRAINT NN__Rentree__project_id CHECK ("project_id" IS NOT NULL),
    CONSTRAINT NN__Rentree__organisme_id CHECK ("organisme_id" IS NOT NULL),
    CONSTRAINT NN__Rentree__montant CHECK ("montant" IS NOT NULL),
    CONSTRAINT NN__Rentree__date_facturation CHECK ("date_facturation" IS NOT NULL),
    CONSTRAINT NN__Rentree__motif CHECK ("motif" IS NOT NULL),

    CONSTRAINT FK__Rentree__libele_id FOREIGN KEY ("libele_id") REFERENCES "Libele"("id_libele"),
    CONSTRAINT FK__Rentree__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__Rentree__organisme_id FOREIGN KEY ("organisme_id") REFERENCES "Organisme"("id_organisme")
);

CREATE TABLE "Prevision_Rentree" (
    "id_prevision_rentree"  INT GENERATED BY DEFAULT AS IDENTITY,
    "libele_id"             INT,
    "project_id"            INT,
    "organisme_id"          INT,
    "date"                  TIMESTAMP,
    "motif"                 VARCHAR(255),
    "montant"               DECIMAL,

    CONSTRAINT PK__Prevision_Rentree PRIMARY KEY ("id_prevision_rentree"),

    CONSTRAINT NN__Prevision_Rentree__libele_id CHECK ("libele_id" IS NOT NULL),
    CONSTRAINT NN__Prevision_Rentree__project_id CHECK ("project_id" IS NOT NULL),
    CONSTRAINT NN__Prevision_Rentree__date CHECK ("date" IS NOT NULL),
    CONSTRAINT NN__Prevision_Rentree__montant CHECK ("montant" IS NOT NULL),

    CONSTRAINT FK__Prevision_Rentree__libele_id FOREIGN KEY ("libele_id") REFERENCES "Libele"("id_libele"),
    CONSTRAINT FK__Prevision_Rentree__project_id FOREIGN KEY ("project_id") REFERENCES "Project"("id_project"),
    CONSTRAINT FK__Prevision_Rentree__organisme_id FOREIGN KEY ("organisme_id") REFERENCES "Organisme"("id_organisme")
);

CREATE FUNCTION calculate_interval_worktime("start" timestamp, "end" timestamp)
    RETURNS INT AS $$
BEGIN
    RETURN CEIL(EXTRACT(EPOCH FROM AGE("end", "start")) / 3600);
END;
$$ LANGUAGE plpgsql;

CREATE VIEW V_GetProjects AS
SELECT
    p."id_project" AS "IdProject",
    p."isActive" AS "IsActive",
    p."name",
    p."organisme_id" AS "OrganismeId",
    o."name" AS "OrganismeName",
    p."color" AS "Color",
    p."montant_budget" AS "MontantBudget",
    p."date_debut_projet" AS "DateDebutProjet",
    p."date_fin_projet" AS "DateFinProjet",
    p."charge_de_projet" AS "ChargeDeProjetId",
    CONCAT_WS(' ', u.prenom, u.nom) AS "ChargeDeProjetName",
    prevision_depense.montant AS "PrevisionDepenseActuelle",
    depense.montant AS "DepenseReelActuelle"
FROM "Project" p
INNER JOIN "Organisme" o ON p.organisme_id = o.id_organisme
INNER JOIN "User" u ON p.charge_de_projet = u.id_user
LEFT JOIN (
    SELECT project_id, SUM(montant) AS montant
    FROM (
        SELECT project_id, montant, date
        FROM "Prevision_Budget_Category"
        UNION ALL
        SELECT project_id,montant, date
        FROM "Prevision_Budget_Libele"
    ) prevision_depense
    WHERE date <= NOW()
    GROUP BY project_id
) prevision_depense ON prevision_depense.project_id = p.id_project
LEFT JOIN (
    SELECT project_id, SUM(montant) AS "montant"
    FROM "Depense"
    WHERE date_facturation <= NOW()
    GROUP BY project_id
) depense ON depense.project_id = p.id_project
ORDER BY "DateDebutProjet" DESC;

CREATE FUNCTION get_cumulative_rentree(id INT)
RETURNS TABLE (
    "month_year" TEXT,
    "cumulative_montant_prevision" NUMERIC,
    "cumulative_montant_reel" NUMERIC
) AS $$
BEGIN
    RETURN QUERY
        WITH inOut_prevision AS (
            SELECT TO_CHAR(d.date, 'MM-YYYY') "date", SUM(d.montant) montant
            FROM "Prevision_Budget_Libele" d
                     INNER JOIN "Libele" l ON d.libele_id = l.id_libele
                     INNER JOIN "Category" c ON l.category_id = c.id_category
            WHERE project_id = id
              AND c."isIncome" = true
              AND d.date <= NOW()
            GROUP BY "date"

            UNION

            SELECT TO_CHAR(d.date, 'MM-YYYY'), SUM(d.montant)
            FROM "Prevision_Budget_Category" d
                     INNER JOIN "Category" c ON d.category_id = c.id_category
            WHERE project_id = id
              AND c."isIncome" = true
              AND d.date <= NOW()
            GROUP BY "date"
        ),
         inOut_Reel AS (
             SELECT TO_CHAR(r.date_facturation, 'MM-YYYY') "date", SUM(r.montant) montant
             FROM "Rentree" r
                      INNER JOIN "Libele" l ON r.libele_id = l.id_libele
                      INNER JOIN "Category" c ON l.category_id = c.id_category
             WHERE project_id = id
               AND r.date_facturation <= NOW()
             GROUP BY "date"
         ),
         generate_date AS (
             SELECT DISTINCT TO_CHAR(generate_series(date_debut_projet, NOW(), '1 month'), 'MM-YYYY') AS "date"
             FROM "Project"
             WHERE id_project = id
         ),
         group_combinations AS (
             SELECT
                 gd."date",
                 COALESCE(p.montant, 0) AS montant_previ,
                 null AS montant_reel
             FROM generate_date gd
                      LEFT JOIN  inOut_prevision p ON p.date = gd.date
             UNION
             SELECT
                 gd."date",
                 null,
                 COALESCE(r.montant, 0)
             FROM generate_date gd
                      LEFT JOIN  inOut_Reel r ON r.date = gd.date
         ),
         avengers_assemble AS (
             SELECT
                 date,
                 SUM(montant_previ) as montant_previ,
                 SUM(montant_reel) as montant_reel
             FROM group_combinations
             GROUP BY date
         )
    SELECT
        "date",
        SUM(montant_previ) OVER(ORDER BY "date") AS cumulative_montant_prevision,
        SUM(montant_reel) OVER(ORDER BY "date") AS cumulative_montant_reel
    FROM avengers_assemble
    ORDER BY "date";
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION get_cumulative_depense(id INT)
RETURNS TABLE (
    "month_year" TEXT,
    cumulative_montant_prevision NUMERIC,
    cumulative_montant_reel NUMERIC
) AS $$
BEGIN
    RETURN QUERY
        WITH inOut_prevision AS (
            SELECT TO_CHAR(d.date, 'MM-YYYY') "date", SUM(d.montant) montant
            FROM "Prevision_Budget_Libele" d
                     INNER JOIN "Libele" l ON d.libele_id = l.id_libele
                     INNER JOIN "Category" c ON l.category_id = c.id_category
            WHERE project_id = id
              AND c."isIncome" = false
              AND d.date <= NOW()
            GROUP BY "date"

            UNION

            SELECT TO_CHAR(d.date, 'MM-YYYY'), SUM(d.montant)
            FROM "Prevision_Budget_Category" d
                     INNER JOIN "Category" c ON d.category_id = c.id_category
            WHERE project_id = id
              AND c."isIncome" = false
              AND d.date <= NOW()
            GROUP BY "date"
        ),
             inOut_Reel AS (
                 SELECT TO_CHAR(d.date_facturation, 'MM-YYYY') "date", SUM(d.montant) montant
                 FROM "Depense" d
                          INNER JOIN "Libele" l ON d.libele_id = l.id_libele
                          INNER JOIN "Category" c ON l.category_id = c.id_category
                 WHERE project_id = id
                   AND d.date_facturation <= NOW()
                 GROUP BY "date"
             ),
             generate_date AS (
                 SELECT DISTINCT TO_CHAR(generate_series(date_debut_projet, NOW(), '1 month'), 'MM-YYYY') AS "date"
                 FROM "Project"
                 WHERE id_project = id
             ),
             group_combinations AS (
                 SELECT
                     gd."date",
                     COALESCE(p.montant, 0) AS montant_previ,
                     null AS montant_reel
                 FROM generate_date gd
                          LEFT JOIN  inOut_prevision p ON p.date = gd.date
                 UNION
                 SELECT
                     gd."date",
                     null,
                     COALESCE(r.montant, 0)
                 FROM generate_date gd
                          LEFT JOIN  inOut_Reel r ON r.date = gd.date
             ),
             avengers_assemble AS (
                 SELECT
                     date,
                     SUM(montant_previ) as montant_previ,
                     SUM(montant_reel) as montant_reel
                 FROM group_combinations
                 GROUP BY date
             )
        SELECT
            "date",
            SUM(montant_previ) OVER(ORDER BY "date") AS cumulative_montant_prevision,
            SUM(montant_reel) OVER(ORDER BY "date") AS cumulative_montant_reel
        FROM avengers_assemble
        ORDER BY "date";
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION get_all_inOut_for_project(id INT, use_depenses BOOLEAN)
RETURNS TABLE (
    "Category"  VARCHAR,
    "Libele"    VARCHAR,
    "Date"      TEXT,
    "Montant"   DECIMAL
) AS $$
BEGIN
    CREATE TEMP TABLE IF NOT EXISTS inOut (
        category VARCHAR,
        IdCategory INT,
        libelle VARCHAR,
        IdLibelle INT,
        Organisme VARCHAR,
        motif VARCHAR,
        Date TIMESTAMP,
        Montant decimal
    ) ON COMMIT DROP;

    IF use_depenses THEN
        INSERT INTO inOut
        SELECT c.name Category, c.id_category, l.name Libele, l.id_libele, o.name Organisme, d.motif, d.date_facturation, d.montant
        FROM "Depense" d
        INNER JOIN "Libele" l ON d.libele_id = l.id_libele
        INNER JOIN "Category" c ON l.category_id = c.id_category
        LEFT JOIN "Organisme" o ON o.id_organisme = d.organisme_id
        WHERE project_id = id;
    ELSE
        INSERT INTO inOut
        SELECT c.name Category, c.id_category, l.name Libele, l.id_libele, o.name Organisme, r.motif, r.date_facturation, r.montant
        FROM "Rentree" r
        INNER JOIN "Libele" l ON r.libele_id = l.id_libele
        INNER JOIN "Category" c ON l.category_id = c.id_category
        LEFT JOIN "Organisme" o ON o.id_organisme = r.organisme_id
        WHERE project_id = id;
    END IF;

    RETURN QUERY
    WITH calendar AS (
        SELECT TO_CHAR(generate_series("Project".date_debut_projet, now(), '1 month'), 'MM-YYYY') AS "date"
        FROM "Project"
        WHERE id_project = id
    ),
    all_combinations AS (
        SELECT c."date", l.Category, l.IdCategory, l.Libelle, l.IdLibelle
        FROM calendar c
        CROSS JOIN inOut l
    )
    SELECT
        ac.Category,
        ac.Libelle,
        ac."date",
        COALESCE(SUM(i.montant), 0) AS Montant
    FROM all_combinations ac
    LEFT JOIN inOut i ON TO_CHAR(i.Date, 'MM-YYYY') = ac.date AND i.IdCategory = ac.IdCategory AND i.IdLibelle = ac.IdLibelle
    GROUP BY ac."date", ac.Category, ac.Libelle
    ORDER BY ac.Category, ac.Libelle, ac."date";
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION get_counters_for_user(id INT)
RETURNS TABLE (
    "Category"  VARCHAR,
    "Max"       DECIMAL,
    "Utilise"   DECIMAL,
    "Solde"     DECIMAL
) AS $$
BEGIN
    RETURN QUERY
    WITH PrepareHeuresSup AS (
        SELECT
            "category_id",
            EXTRACT(ISODOW FROM "start") dayofweek,
            calculate_interval_worktime("start", "end") heures
        FROM "WorkTime"
        WHERE user_id = id
        AND category_id <> 7
    ),
    HeuresSup AS (
        SELECT
            "category_id",
            CASE
                WHEN dayofweek = 6 THEN Heures * 1.5
                WHEN dayofweek = 7 THEN Heures * 2
                ELSE Heures
            END AS Heures
        FROM PrepareHeuresSup
        WHERE Heures > 8
    ),
    compteur AS (
        SELECT
            "workTime_category_id" AS category_id,
            "quantity" AS max
        FROM "Compteur_WorkTime_Category"
        WHERE user_id = id
    ),
    cross_heuressup_compteur AS (
        SELECT category_id, SUM(Heures) AS Heures
        FROM (
            SELECT category_id, Heures
            FROM HeuresSup
            UNION
            SELECT category_id, max
            FROM compteur
        ) data
        GROUP BY category_id
    ),
    utilise AS (
        SELECT DISTINCT wc."id_workTime_category", wc."abreviation", COALESCE(SUM("hours"), 0) AS count
        FROM (
            SELECT
                "id_WorkTime",
                "category_id",
                "project_id",
                calculate_interval_worktime("start","end") AS hours
            FROM "WorkTime" w
            WHERE EXTRACT(YEAR FROM start) = EXTRACT(YEAR FROM NOW())
            AND user_id = id
        ) wr
        RIGHT JOIN "WorkTime_Category" wc ON "wr".category_id = wc."id_workTime_category"
        WHERE "id_workTime_category" <> 7
        GROUP BY wc."id_workTime_category", wc."abreviation"
        ORDER BY wc."id_workTime_category"
    )
    SELECT
        u.abreviation as Category,
        c.Heures::decimal as Max,
        u.count::decimal as Counter,
        (c.Heures-u.count)::decimal as Solde
    FROM utilise u
    FULL JOIN cross_heuressup_compteur c ON u."id_workTime_category" = c.category_id;
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION get_TotalDays_By_Project(startDate TIMESTAMP, endDate TIMESTAMP)
RETURNS TABLE (
    "ProjectId"     VARCHAR,
    "ProjectName"   VARCHAR,
    "TotalDays"     DECIMAL
) AS $$
BEGIN
    RETURN QUERY
    WITH work AS (
        SELECT
            COALESCE(w.project_id, 0) AS projectId,
            COALESCE(p.name, 'Vie IEC') AS projectName,
            calculate_interval_worktime(w."start", w."end") AS projectHours
        FROM "WorkTime" w
        LEFT JOIN "Project" p ON w.project_id = p.id_project
        WHERE w.category_id = 7
        AND (p.date_debut_projet BETWEEN startDate AND endDate OR w.project_id IS NULL)
        AND (p.date_fin_projet BETWEEN startDate AND endDate OR w.project_id IS NULL)
    ),
    projects AS (
        SELECT "Project".id_project,"Project".name
        FROM "Project"
        WHERE date_debut_projet BETWEEN startDate AND endDate
        AND date_fin_projet BETWEEN startDate AND endDate
        UNION ALL
        SELECT 0, 'Vie IEC'
    )
    SELECT
        CASE
            WHEN p.id_project = 0 THEN 'VIEC'
            ELSE p.id_project::varchar
        END AS ProjectId,
        p.name,
        COALESCE(ROUND(SUM(w.projectHours)::DEC/8, 2), 0) AS TotalDays
    FROM projects p
    LEFT JOIN work w ON p.id_project = w.projectId
    GROUP BY p.id_project, p.name
    ORDER BY TotalDays DESC NULLS LAST;
END;
$$ LANGUAGE plpgsql;
