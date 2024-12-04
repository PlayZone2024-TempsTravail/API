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
(3,'VOIR_POINTAGE'),
(3,'VOIR_ALL_POINTAGES'),
(3,'AJOUTER_POINTAGE'),
(3,'MODIFIER_POINTAGE'),
(3,'SUPPRIMER_POINTAGE'),
(3,'VOIR_ROLES'),
(3,'AJOUTER_ROLE'),
(3,'MODIFIER_ROLE'),
(3,'SUPPRIMER_ROLE'),
(3, 'DEBUG_PERMISSION');

INSERT INTO "User" ("id_user", nom, prenom, email, password) VALUES
(1, 'Hanse', 'Steven', 'steven@tech.be', 'password1'),
(2, 'Louis', 'Patigny', 'louis.grand@tech.be', 'password2'),
(3, 'Seb', 'Dendal', 'seb@tech.be', 'password3'),
(4, 'Louis', 'Delleur', 'louis.petit@tech.be', 'password4'),
(5, 'Jerome', 'Tcherepachin', 'jerome@tech.be', 'password5');
ALTER TABLE "User" ALTER COLUMN "id_user" RESTART WITH 6;

INSERT INTO "User_Role" VALUES
(1, 3),
(2, 3),
(3, 3),
(4, 3),
(5, 3);

INSERT INTO "Organisme" VALUES
(1, 'Technobel'),
(2, 'Technocité'),
(3, 'Technofutur'),
(4, 'Technocampus'),
(5, 'J''ai plus d''idee'),
(6, 'Euromillion');
ALTER TABLE "Organisme" ALTER COLUMN "id_organisme" RESTART WITH 7;

INSERT INTO "Project" VALUES
(1, 1, true, 'Projet 1', 200000, '800080FF','2024-01-01', '2024-12-31', 1),
(2, 2, true, 'Projet 2', 200000, '40E0D0FF','2024-01-01', '2024-12-31', 2),
(3, 3, true, 'Projet 3', 200000, 'FFC0CBFF','2024-01-01', '2024-12-31', 3),
(4, 5, false,'Projet 4', 200000, 'D3D3D3FF','2024-01-01', '2024-12-31', 4),
(5, 5, true, 'Projet 5', 200000, '00FF00FF','2024-01-01', '2024-12-31', 5);
ALTER TABLE "Project" ALTER COLUMN "id_project" RESTART WITH 6;

INSERT INTO "WorkTime_Category" VALUES
(1, true, 'RC', 'Récupération', 'FF0000FF'),
(2, true, 'VA', 'Vacances annuelles', '00FF00FF'),
(3, true, 'VAEX', 'Vacances extra légales', '0000FFFF'),
(4, true, 'JF', 'Jour férié', 'FFFF00FF'),
(5, true, 'MA','Maladie', '00FFFFFF'),
(6, true, 'CSS', 'Congé sans solde', 'FF00FFFF'),
(7, true, 'VIEC', 'Vie IEC', 'FFA500FF');
ALTER TABLE "WorkTime_Category" ALTER COLUMN "id_workTime_category" RESTART WITH 8;

INSERT INTO "WorkTime" VALUES
(1, '2024-11-08 08:00:00', '2024-11-08 11:59:59', true, 1, null,2),
(2, '2024-11-09 09:00:00', '2024-11-09 12:59:59', false, 1,null,2),
(3, '2024-11-10 10:00:00', '2024-11-10 13:59:59', true, 3, null, 2),
(4, '2024-11-11 11:00:00', '2024-11-11 14:59:59', false, 4, null, 2),
(5, '2024-11-12 12:00:00', '2024-11-12 15:59:59', true, 5, null, 2),
(6, '2024-11-13 13:00:00', '2024-11-13 16:59:59', true, 6, null, 2),
(7, '2024-11-14 08:00:00', '2024-11-14 13:59:59', true, 7, 1, 2),
(8, '2024-11-14 14:00:00', '2024-11-14 17:59:59', true, 7, null, 2);
ALTER TABLE "WorkTime" ALTER COLUMN "id_WorkTime" RESTART WITH 9;

INSERT INTO "Compteur_WorkTime_Category" VALUES
(1, 1, 10),
(2, 1, 11),
(3, 1, 12),
(4, 1, 13),
(5, 1, 14);

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

INSERT INTO "Prevision_Budget_Category" VALUES
(1, 1, 1, '2024-11-26', 'Euromillion', 10000000),
(2, 1, 2, '2024-12-25', 'Les externes, ca coute cher', '10000'),
(3, 1, 3, '2024-11-30', 'J''ai envie de mettre une couille mais il n''y pas de champs pour mettre une photo', 200000),
(4, 1, 5, '2024-12-01', 'L''investissement serait d''avoir de vrais admin sys mais on peut pas tout avoir', 50000);
ALTER TABLE "Prevision_Budget_Category" ALTER COLUMN "id_prevision_budget_category" RESTART WITH 5;

INSERT INTO "Prevision_Budget_Libele" VALUES
(1, 1, 22, '2024-11-30', null, 1000),
(2, 1, 23, '2024-11-30', 'Moi j''adore l''eau, dans 20 ou 30 ans y en aura plus. J''espère que non', 100),
(3, 1, 24, '2024-11-29', 'Les charges TIC, c''est comme les charges locatives mais pour les ordis', 100),
(4, 1, 25, '2024-11-29', 'Tout ca pour faire la conversation à mamy', 100),
(5, 1, 26, '2024-11-29', 'Les frais postaux, ca existe encore ?', 100),
(6, 1, 27, '2024-11-29', 'Avec tout les vols de bic, faut bien en rachater', 50),
(7, 1, 28, '2024-11-29', 'On rachète une souris chaque mois... parce que... pourquoi pas ?', 150),
(8, 1, 29, '2024-11-28', null,  150),
(9, 1, 30, '2024-11-27', null, 150);
ALTER TABLE "Prevision_Budget_Libele" ALTER COLUMN "id_prevision_budget_libele" RESTART WITH 10;

INSERT INTO "Depense" VALUES
(1, 23, 1, null, 1000, '2024-11-25', null, 'L''alcool, c''est de l''eau'),
(2, 24, 1, null, 200, '2024-12-02', null, 'La souris a couté plus cher finalement, LOGITECH ❤'),
(3, 25, 1, null, 300, '2024-12-03', null, 'Je suis sur que c''est pas pour mamy'),
(4, 26, 1, null, 400, '2024-12-04', null, 'Les pigeons voyageurs, c''est plus ce que c''était'),
(5, 27, 1, null, 500, '2024-12-05', null, 'Les vols de bic, c''est un fléau');
ALTER TABLE "Depense" ALTER COLUMN "id_depense" RESTART WITH 6;

INSERT INTO "Rentree" VALUES
(1, 4, 1, 6, 1, '2024-12-23', 'Finalement, on a pas gagné');
ALTER TABLE "Rentree" ALTER COLUMN "id_rentree" RESTART WITH 2;

