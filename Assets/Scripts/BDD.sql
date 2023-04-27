CREATE TABLE `User` (
  `user_id` INTEGER PRIMARY KEY AUTO_INCREMENT,
  `user_name` TEXT,
  `user_score` integer,
  `user_best_score` integer
);

CREATE TABLE `Card` (
  `card_id` integer PRIMARY KEY AUTO_INCREMENT,
  `card_name` TEXT,
  `card_action` TEXT,
  `card_desc` TEXT,
  `card_value` INTEGER
);

CREATE TABLE `UserCard` (
  `user_id` INTEGER,
  `card_id` INTEGER
);

CREATE TABLE `Board` (
  `board_id` INTEGER PRIMARY KEY AUTO_INCREMENT,
  `board_user` INTEGER,
  `board_case` INTEGER
);

CREATE TABLE `BoardPlayer` (
  `board_id` INTEGER,
  `user_id` INTEGER
);

CREATE TABLE `Box` (
  `box_id` INTEGER PRIMARY KEY AUTO_INCREMENT,
  `box_owner` INTEGER,
  `box_desc` TEXT,
  `box_build` INTEGER
);

CREATE TABLE `BoardBox` (
  `board_id` INTEGER,
  `box_id` INTEGER
);

ALTER TABLE `UserCard` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`user_id`);

ALTER TABLE `UserCard` ADD FOREIGN KEY (`card_id`) REFERENCES `Card` (`card_id`);

ALTER TABLE `BoardPlayer` ADD FOREIGN KEY (`board_id`) REFERENCES `Board` (`board_id`);

ALTER TABLE `BoardPlayer` ADD FOREIGN KEY (`user_id`) REFERENCES `User` (`user_id`);

ALTER TABLE `BoardBox` ADD FOREIGN KEY (`board_id`) REFERENCES `Board` (`board_id`);

ALTER TABLE `BoardBox` ADD FOREIGN KEY (`box_id`) REFERENCES `Box` (`box_id`);
