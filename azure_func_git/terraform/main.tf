resource "azurerm_resource_group" "main" {
  name     = "myResourceGroup" #"rg-${var.application_name}-${var.environment_name}"
  #name     = var.resource_group_name
  location = var.location
}

# resource "random_string" "name" {
#   length  = 8
#   special = false
#   upper   = false
# }

data "azurerm_client_config" "current" {}