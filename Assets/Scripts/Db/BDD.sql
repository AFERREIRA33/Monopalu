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

CREATE TABLE UserCard (
  user_id INTEGER,
  card_id INTEGER
  FOREIGN KEY(user_id) REFERENCES User(user_id),
  FOREIGN KEY(card_id) REFERENCES Card(card_id)
);

CREATE TABLE Board (
  board_id INTEGER PRIMARY KEY AUTOINCREMENT,
  board_user INTEGER,
  board_case INTEGER
);

CREATE TABLE BoardPlayer (
  board_id INTEGER,
  user_id INTEGER,
  FOREIGN KEY (board_id) REFERENCES Board(board_id),
  FOREIGN KEY (board_id) REFERENCES Board(board_id)
);

CREATE TABLE Box (
  box_id INTEGER PRIMARY KEY AUTOINCREMENT,
  box_owner INTEGER,
  box_desc TEXT,
  box_build INTEGER
);

CREATE TABLE BoardBox (
  board_id INTEGER,
  box_id INTEGER
  FOREIGN KEY (board_id) REFERENCES Board(board_id),
  FOREIGN KEY (box_id) REFERENCES Box(box_id)
);
