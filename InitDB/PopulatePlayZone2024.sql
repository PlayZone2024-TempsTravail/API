INSERT INTO "Role" (id_role, name) VALUES
(1, 'Employe'),
(2, 'Charge de Projet'),
(3, 'Admin');
ALTER TABLE "Role" ALTER COLUMN "id_role" RESTART WITH 4;

INSERT INTO "Role_Permission" (role_id, permission_id) VALUES
(1,'VOIR_POINTAGE'),
(1,'AJOUTER_POINTAGE'),
(3,'VOIR_USERS'),
(3,'AJOUTER_USER'),
(3,'SUPPRIMER_USER'),
(3,'MODIFIER_USER'),
(3,'PERSO_CONSULTER_POINTAGE'),
(3,'PERSO_AJOUTER_POINTAGE'),
(3,'PERSO_MODIFIER_POINTAGE'),
(3,'PERSO_SUPPRIMER_POINTAGE'),
(3,'ALL_CONSULTER_POINTAGES'),
(3,'ALL_AJOUTER_POINTAGE'),
(3,'ALL_MODIFIER_POINTAGE'),
(3,'ALL_SUPPRIMER_POINTAGE'),
(3,'VOIR_ROLES'),
(3,'AJOUTER_ROLE'),
(3,'MODIFIER_ROLE'),
(3,'MODIFIER_PERMISSIONS'),
(3,'SUPPRIMER_ROLE'),
(3,'DEBUG_PERMISSION'),
(3,'EDITER_COMPTEUR'),
(3,'EDITER_USER_SALAIRE'),
(3,'MODIFIER_CATEGORIE_POINTAGE'),
(3,'MODIFIER_CATEGORIE'),
(3,'MODIFIER_PREVISION_CATEGORIE'),
(3,'SUPPRIMER_PREVISION_CATEGORIE'),
(3,'VOIR_PROJETS'),
(3,'AJOUTER_PROJET'),
(3,'MODIFIER_PROJET'),
(3,'SUPPRIMER_PROJET'),
(3,'MODIFIER_LIBELLE'),
(3,'MODIFIER_ORGANISME'),
(3,'SUPPRIMER_ORGANISME'),
(3,'MODIFIER_RENTREE'),
(3,'SUPPRIMER_RENTREE'),
(3,'MODIFIER_PREVISION_RENTREE'),
(3,'SUPPRIMER_PREVISION_RENTREE'),
(3,'MODIFIER_DEPENSE'),
(3,'SUPPRIMER_DEPENSE'),
(3,'MODIFIER_PREVISION_DEPENSE'),
(3,'SUPPRIMER_PREVISION_DEPENSE'),
(3,'MODIFIER_CONFIGURATION'),
(3,'VOIR_RAPPORT');

INSERT INTO "User" ("id_user", nom, prenom, email, password) VALUES
(1, 'HIEN', 'Jean-Baptiste', 'waangele.hien@eco-conseil.be', '173af466c81f1bea4bd9a600d07584456db2460163d27420a4e86db78f7335fc');
ALTER TABLE "User" ALTER COLUMN "id_user" RESTART WITH 2;

INSERT INTO "User_Role" VALUES
(1, 3);

INSERT INTO "WorkTime_Category" VALUES
(1, true, 'RC', 'Récupération', 'FF0000FF'),
(2, true, 'VA', 'Vacances annuelles', '00FF00FF'),
(3, true, 'VAEX', 'Vacances extra légales', '0000FFFF'),
(4, true, 'JF', 'Jour férié', 'FFFF00FF'),
(5, true, 'MA','Maladie', '00FFFFFF'),
(6, true, 'CSS', 'Congé sans solde', 'FF00FFFF'),
(7, true, 'VIEC', 'Vie IEC', 'FFA500FF');
ALTER TABLE "WorkTime_Category" ALTER COLUMN "id_workTime_category" RESTART WITH 8;

INSERT INTO "Category" VALUES
(1, 'Entree', true, true),
(2, 'Renumeration', false, true),
(3, 'Fonctionnement - Frais Specifique au projet', false, true),
(4, 'Fonctionnement - Frais Generaux', false, false),
(5, 'Investissement', false, false);
ALTER TABLE "Category" ALTER COLUMN "id_category" RESTART WITH 6;

INSERT INTO "Libele" VALUES
(1, 1, 'Subvention/Subside'),
(2, 1, 'Qote-Part APE'),
(3, 1, 'Frais de participation'),
(4, 1, 'Autres'),
(5, 2, 'Frais de personnel IEC'),
(6, 2, 'Experts/Intervenants externes'),
(7, 2, 'Autres'),
(8, 3, 'Achats de livres et de publications'),
(9, 3, 'Achats de matériel et petit équipement'),
(10, 3, 'Frais de catering'),
(11, 3, 'Frais de communications et Pub'),
(12, 3, 'Frais de déplacement mission'),
(13, 3, 'Frais de déplacement internationaux'),
(14, 3, 'Frais de location de salles'),
(15, 3, 'Frais de réalisatio/acquisition de supports pédagogiques'),
(16, 3, 'Frais de séjour (Perdiem)'),
(17, 3, 'Frais de Visa & Assurance'),
(18, 3, 'Frais d''hébergement/logement'),
(19, 3, 'Frais d''impression'),
(20, 3, 'Frais d''organisation d''atelier/séminaire'),
(21, 3, 'Autres frais liés aux projets'),
(22, 4, 'Loyers'),
(23, 4, 'Charges locatives (Eau, Electricité)'),
(24, 4, 'Charges TIC'),
(25, 4, 'Communications téléphoniques'),
(26, 4, 'Frais postaux'),
(27, 4, 'Fournitures de Bureau'),
(28, 4, 'Fournitures informatique'),
(29, 4, 'Entretien et réparation'),
(30, 4, 'Autre'),
(31, 5, 'Matériel et mobilier de bureau'),
(32, 5, 'Matériel informatique'),
(33, 5, 'Autre');
ALTER TABLE "Libele" ALTER COLUMN "id_libele" RESTART WITH 34;

