terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.69.0"
    }
    random = {
      source  = "hashicorp/random"
      version = "~>3.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "rg-alz-bdo-1"
    storage_account_name = "tftestai01"
    container_name       = "webstate"
    key                  = "test.tfstate"
  }
}

provider "azurerm" {
  features {
    key_vault {
      purge_soft_delete_on_destroy    = true
      recover_soft_deleted_key_vaults = true
    }
  }

  subscription_id = "95fe0bf7-2308-4e35-8402-ba715e1eba59"
  tenant_id       = "bc6c3269-ea35-4a25-b977-00c0745036f0"

}