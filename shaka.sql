SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE  TABLE IF NOT EXISTS `euo`.`account` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `username` VARCHAR(20) NOT NULL ,
  `passwd` VARCHAR(20) NOT NULL ,
  `accesslevel` ENUM('Player','Owner') NOT NULL ,
  `flags` INT(11) NOT NULL ,
  `created` TIMESTAMP NOT NULL ,
  `lastlogin` TIMESTAMP NOT NULL ,
  `totalgametime` TIME NOT NULL ,
  `youngduration` TIME NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `IDX_USERNAME` (`username` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`attributereq` (
  `id` INT(11) NOT NULL ,
  `int` DOUBLE NOT NULL DEFAULT 0 ,
  `dex` DOUBLE NOT NULL DEFAULT 0 ,
  `str` DOUBLE NOT NULL DEFAULT 0 ,
  `hitpoint` INT(11) NOT NULL DEFAULT 0 ,
  `mana` INT(11) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`attributes` (
  `id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`bank` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `container_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_bank_container1` (`container_id` ASC) ,
  CONSTRAINT `fk_bank_container1`
    FOREIGN KEY (`container_id` )
    REFERENCES `euo`.`container` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`container_has_item` (
  `container_id` INT(11) NOT NULL ,
  `item_id` INT(11) NOT NULL ,
  PRIMARY KEY (`container_id`, `item_id`) ,
  INDEX `fk_container_has_item_container1` (`container_id` ASC) ,
  INDEX `fk_container_has_item_item1` (`item_id` ASC) ,
  CONSTRAINT `fk_container_has_item_container1`
    FOREIGN KEY (`container_id` )
    REFERENCES `euo`.`container` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_container_has_item_item1`
    FOREIGN KEY (`item_id` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`container` (
  `id` INT(11) NOT NULL ,
  `item_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_container_item1` (`item_id` ASC) ,
  INDEX `idx_item_id` (`item_id` ASC) ,
  CONSTRAINT `fk_container_item1`
    FOREIGN KEY (`item_id` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`crafting` (
  `id` INT(11) NOT NULL ,
  `resource_needed` INT(11) NOT NULL ,
  `crafted_item` INT(11) NOT NULL ,
  `quantity` INT(11) NOT NULL DEFAULT 1 ,
  `consume` TINYINT(1) NOT NULL DEFAULT True ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_crafting_itemtype1` (`resource_needed` ASC) ,
  INDEX `fk_crafting_itemtype2` (`crafted_item` ASC) ,
  CONSTRAINT `fk_crafting_itemtype1`
    FOREIGN KEY (`resource_needed` )
    REFERENCES `euo`.`itemtype` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_crafting_itemtype2`
    FOREIGN KEY (`crafted_item` )
    REFERENCES `euo`.`itemtype` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`gears` (
  `id` INT(11) NOT NULL ,
  `head` INT(11) NULL DEFAULT NULL ,
  `chest` INT(11) NULL DEFAULT NULL ,
  `arms` INT(11) NULL DEFAULT NULL ,
  `gloves` INT(11) NULL DEFAULT NULL ,
  `legs` INT(11) NULL DEFAULT NULL ,
  `shoes` INT(11) NULL DEFAULT NULL ,
  `ring` INT(11) NULL DEFAULT NULL ,
  `lefthand` INT(11) NULL DEFAULT NULL ,
  `righthand` INT(11) NULL DEFAULT NULL ,
  `bracelet` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_gears_item1` (`head` ASC) ,
  INDEX `fk_gears_item2` (`chest` ASC) ,
  INDEX `fk_gears_item3` (`arms` ASC) ,
  INDEX `fk_gears_item4` (`gloves` ASC) ,
  INDEX `fk_gears_item5` (`legs` ASC) ,
  INDEX `fk_gears_item6` (`shoes` ASC) ,
  INDEX `fk_gears_item7` (`ring` ASC) ,
  INDEX `fk_gears_item8` (`lefthand` ASC) ,
  INDEX `fk_gears_item9` (`righthand` ASC) ,
  INDEX `fk_gears_item10` (`bracelet` ASC) ,
  CONSTRAINT `fk_gears_item1`
    FOREIGN KEY (`head` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item2`
    FOREIGN KEY (`chest` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item3`
    FOREIGN KEY (`arms` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item4`
    FOREIGN KEY (`gloves` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item5`
    FOREIGN KEY (`legs` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item6`
    FOREIGN KEY (`shoes` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item7`
    FOREIGN KEY (`ring` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item8`
    FOREIGN KEY (`lefthand` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item9`
    FOREIGN KEY (`righthand` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_gears_item10`
    FOREIGN KEY (`bracelet` )
    REFERENCES `euo`.`item` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`guild` (
  `id` INT(11) NOT NULL ,
  `owner` INT(11) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_guild_player1` (`owner` ASC) ,
  CONSTRAINT `fk_guild_player1`
    FOREIGN KEY (`owner` )
    REFERENCES `euo`.`player` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`itemtype` (
  `id` INT(11) NOT NULL ,
  `attributereq_id` INT(11) NOT NULL ,
  `skillreq_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_itemtype_attributereq1` (`attributereq_id` ASC) ,
  INDEX `fk_itemtype_skillreq1` (`skillreq_id` ASC) ,
  CONSTRAINT `fk_itemtype_attributereq1`
    FOREIGN KEY (`attributereq_id` )
    REFERENCES `euo`.`attributereq` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_itemtype_skillreq1`
    FOREIGN KEY (`skillreq_id` )
    REFERENCES `euo`.`skillreq` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`item` (
  `id` INT(11) NOT NULL ,
  `itemtype_id` INT(11) NOT NULL ,
  `resistances_id` INT(11) NOT NULL ,
  `styles_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_item_itemtype1` (`itemtype_id` ASC) ,
  INDEX `fk_item_resistances1` (`resistances_id` ASC) ,
  INDEX `fk_item_styles1` (`styles_id` ASC) ,
  CONSTRAINT `fk_item_itemtype1`
    FOREIGN KEY (`itemtype_id` )
    REFERENCES `euo`.`itemtype` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_item_resistances1`
    FOREIGN KEY (`resistances_id` )
    REFERENCES `euo`.`resistances` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_item_styles1`
    FOREIGN KEY (`styles_id` )
    REFERENCES `euo`.`styles` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`mobile` (
  `id` INT(11) NOT NULL ,
  `account_id` INT(11) NULL DEFAULT NULL ,
  `accesslevel` ENUM('Player',	'Counselor', 'GameMaster', 'Seer', 'Administrator',	'Developer', 'Owner') NULL DEFAULT NULL ,
  `alive` TINYINT(1) NOT NULL DEFAULT true ,
  `backpack_id` INT(11) NOT NULL ,
  `attributes_id` INT(11) NOT NULL ,
  `resistances_id` INT(11) NOT NULL ,
  `gears_id` INT(11) NOT NULL ,
  `styles_id` INT(11) NOT NULL ,
  `model` SMALLINT(6) NOT NULL ,
  `x` SMALLINT(6) NOT NULL DEFAULT 2516 ,
  `y` SMALLINT(6) NOT NULL DEFAULT 558 ,
  `z` SMALLINT(6) NOT NULL DEFAULT 0 ,
  `direction` TINYINT(4) NOT NULL DEFAULT 0 ,
  `notoriety` SMALLINT(6) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_mobile_account1` (`account_id` ASC) ,
  INDEX `fk_mobile_container1` (`backpack_id` ASC) ,
  INDEX `fk_mobile_attributes1` (`attributes_id` ASC) ,
  INDEX `fk_mobile_resistances1` (`resistances_id` ASC) ,
  INDEX `fk_mobile_gears1` (`gears_id` ASC) ,
  INDEX `fk_mobile_styles1` (`styles_id` ASC) ,
  CONSTRAINT `fk_mobile_account1`
    FOREIGN KEY (`account_id` )
    REFERENCES `euo`.`account` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mobile_container1`
    FOREIGN KEY (`backpack_id` )
    REFERENCES `euo`.`container` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mobile_attributes1`
    FOREIGN KEY (`attributes_id` )
    REFERENCES `euo`.`attributes` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mobile_resistances1`
    FOREIGN KEY (`resistances_id` )
    REFERENCES `euo`.`resistances` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mobile_gears1`
    FOREIGN KEY (`gears_id` )
    REFERENCES `euo`.`gears` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mobile_styles1`
    FOREIGN KEY (`styles_id` )
    REFERENCES `euo`.`styles` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`monster` (
  `id` INT(11) NOT NULL ,
  `mobile_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_monster_mobile1` (`mobile_id` ASC) ,
  CONSTRAINT `fk_monster_mobile1`
    FOREIGN KEY (`mobile_id` )
    REFERENCES `euo`.`mobile` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`npc` (
  `id` INT(11) NOT NULL ,
  `mobile_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_npc_mobile1` (`mobile_id` ASC) ,
  CONSTRAINT `fk_npc_mobile1`
    FOREIGN KEY (`mobile_id` )
    REFERENCES `euo`.`mobile` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`player` (
  `id` INT(11) NOT NULL ,
  `bank_id` INT(11) NOT NULL ,
  `mobile_id` INT(11) NOT NULL ,
  `guild_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_player_bank1` (`bank_id` ASC) ,
  INDEX `fk_player_mobile1` (`mobile_id` ASC) ,
  INDEX `fk_player_guild1` (`guild_id` ASC) ,
  CONSTRAINT `fk_player_bank1`
    FOREIGN KEY (`bank_id` )
    REFERENCES `euo`.`bank` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_player_mobile1`
    FOREIGN KEY (`mobile_id` )
    REFERENCES `euo`.`mobile` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_player_guild1`
    FOREIGN KEY (`guild_id` )
    REFERENCES `euo`.`guild` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`resistances` (
  `id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`skilllist` (
  `id` INT(11) NOT NULL ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`skillreq` (
  `id` INT(11) NOT NULL ,
  `skill_id` INT(11) NOT NULL ,
  `value` DOUBLE NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_skillreq_skill1` (`skill_id` ASC) ,
  CONSTRAINT `fk_skillreq_skill1`
    FOREIGN KEY (`skill_id` )
    REFERENCES `euo`.`skill` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`skill` (
  `id` INT(11) NOT NULL ,
  `skilllist_id` INT(11) NOT NULL ,
  `value` DOUBLE NOT NULL DEFAULT 0 ,
  `mobile_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_skill_skilllist1` (`skilllist_id` ASC) ,
  INDEX `fk_skill_mobile1` (`mobile_id` ASC) ,
  INDEX `idx_mobile_id` (`mobile_id` ASC) ,
  CONSTRAINT `fk_skill_skilllist1`
    FOREIGN KEY (`skilllist_id` )
    REFERENCES `euo`.`skilllist` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_mobile1`
    FOREIGN KEY (`mobile_id` )
    REFERENCES `euo`.`mobile` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`spellreag` (
  `id` INT(11) NOT NULL ,
  `itemtype_id` INT(11) NOT NULL ,
  `quantity` VARCHAR(45) NOT NULL DEFAULT 0 ,
  `spell_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_spellreag_itemtype1` (`itemtype_id` ASC) ,
  INDEX `fk_spellreag_spell1` (`spell_id` ASC) ,
  INDEX `idx_spell_id` (`spell_id` ASC) ,
  CONSTRAINT `fk_spellreag_itemtype1`
    FOREIGN KEY (`itemtype_id` )
    REFERENCES `euo`.`itemtype` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_spellreag_spell1`
    FOREIGN KEY (`spell_id` )
    REFERENCES `euo`.`spell` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`spell` (
  `id` INT(11) NOT NULL ,
  `skillreq_id` INT(11) NOT NULL ,
  `attributereq_id` INT(11) NOT NULL ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_spell_skillreq1` (`skillreq_id` ASC) ,
  INDEX `fk_spell_attributereq1` (`attributereq_id` ASC) ,
  CONSTRAINT `fk_spell_skillreq1`
    FOREIGN KEY (`skillreq_id` )
    REFERENCES `euo`.`skillreq` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_spell_attributereq1`
    FOREIGN KEY (`attributereq_id` )
    REFERENCES `euo`.`attributereq` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`styles` (
  `id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;

CREATE  TABLE IF NOT EXISTS `euo`.`vendor` (
  `id` INT(11) NOT NULL ,
  `mobile_id` INT(11) NOT NULL ,
  `player_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_vendor_mobile1` (`mobile_id` ASC) ,
  INDEX `fk_vendor_player1` (`player_id` ASC) ,
  CONSTRAINT `fk_vendor_mobile1`
    FOREIGN KEY (`mobile_id` )
    REFERENCES `euo`.`mobile` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_vendor_player1`
    FOREIGN KEY (`player_id` )
    REFERENCES `euo`.`player` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
