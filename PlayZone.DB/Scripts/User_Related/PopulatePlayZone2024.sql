INSERT INTO "Role" (id_role, name) VALUES
(1, 'Employe'),
(2, 'Charge de Projet'),
(3, 'Admin');

INSERT INTO "User" (id_user, "role_id", nom, prenom, email, password, heures_annuelles_prestables) VALUES
(1, 3, 'Hanse', 'Steven', 'steven@tech.be', 'password1', 200),
(2, 3, 'Louis', 'Patigny', 'louis.grand@tech.be', 'password2', 200),
(3, 3, 'Seb', 'Dendal', 'seb@tech.be', 'password3', 200),
(4, 3, 'Louis', 'Delleur', 'louis.petit@tech.be', 'password4', 200),
(5, 3, 'Jerome', 'Tcherepachin', 'jerome@tech.be', 'password5', 200);

INSERT INTO "Project" VALUES
(1, 'Projet 1', 200000, '2024-01-01', '2024-06-30', '2024-12-31', 1),
(2, 'Projet 2', 200000, '2024-01-01', '2024-06-30', '2024-12-31', 2),
(3, 'Projet 3', 200000, '2024-01-01', '2024-06-30', '2024-12-31', 3),
(4, 'Projet 4', 200000, '2024-01-01', '2024-06-30', '2024-12-31', 4),
(5, 'Projet 5', 200000, '2024-01-01', '2024-06-30', '2024-12-31', 5);

INSERT INTO "WorkTime_Category" VALUES
('RC', 'Récupération'),
('VA', 'Vacances annuelles'),
('VAEX', 'Vacances extra légales'),
('JF', 'Jour férié'),
('MA','Maladie'),
('CSS', 'Congé sans solde'),
('VIEC', 'Vie IEC');

INSERT INTO "WorkTime" VALUES
(1, '2024-11-08 08:00:00', '2024-11-08 11:59:59', 'RC', null,2),
(2, '2024-11-09 09:00:00', '2024-11-09 12:59:59', 'VA',null,2),
(3, '2024-11-10 10:00:00', '2024-11-10 13:59:59', 'VAEX', null, 2),
(4, '2024-11-11 11:00:00', '2024-11-11 14:59:59', 'JF', null, 2),
(5, '2024-11-12 12:00:00', '2024-11-12 15:59:59', 'MA', null, 2),
(6, '2024-11-13 13:00:00', '2024-11-13 16:59:59', 'CSS', null, 2),
(7, '2024-11-14 08:00:00', '2024-11-14 13:59:59', 'VIEC', 1, 2),
(8, '2024-11-14 14:00:00', '2024-11-14 17:59:59', 'VIEC', null, 2);

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
(3,'SUPPRIMER_ROLE');
