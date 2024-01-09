create table user_role (id bigserial not null, role varchar(255), primary key (id));
create table user_role_users (roles_id bigint not null, users_id bigint not null);
create table users (id bigserial not null, email varchar(255), first_name varchar(255), last_name varchar(255), username varchar(255), password_hash bytea, password_salt bytea, primary key (id));
alter table if exists user_role_users add constraint FKppx9y6k4sog2ma7sq6xmug6ap foreign key (users_id) references users;
alter table if exists user_role_users add constraint FK20vlbjnah23b2ng03xjbk5obn foreign key (roles_id) references user_role;
