Terraform CI/CD Pipelines
This repository contains GitHub Actions workflows that automate Terraform operations for 
managing infrastructure on Azure. The workflows include the following key Terraform actions:

Terraform Plan: Previews the changes that will be made to your infrastructure.
Terraform Apply: Applies the planned changes to your Azure resources.
Terraform Destroy: Destroys the resources managed by Terraform, with a manual confirmation 
step to avoid accidental deletions.
These pipelines ensure a safe, repeatable, and automated process for managing your Azure 
infrastructure with Terraform.

Overview of the Pipelines
1. Terraform Plan Pipeline
The Terraform Plan pipeline generates an execution plan, showing you what changes Terraform 
will apply to your infrastructure. This step is useful for reviewing proposed changes before 
applying them, ensuring that no unintended modifications are made to your infrastructure.

Trigger: The terraform plan pipeline runs automatically on push events to the main branch, 
specifically when changes are made to the Terraform configuration files or workflow files.
Purpose: To preview the infrastructure changes and assess the impact before proceeding with 
actual deployment.
2. Terraform Apply Pipeline
The Terraform Apply pipeline applies the changes specified in the Terraform plan to your 
Azure environment. Once the changes are approved (via the terraform plan step), this 
pipeline applies them in an automated fashion.

Trigger: The terraform apply pipeline runs automatically after the terraform plan pipeline 
is successful.
Purpose: To deploy the changes to your infrastructure as outlined in the Terraform 
configuration files.
3. Terraform Destroy Pipeline
The Terraform Destroy pipeline is designed to safely destroy resources managed by Terraform. 
It is a manual operation, requiring explicit confirmation before the destroy command is 
executed, to prevent accidental loss of infrastructure.

Trigger: The terraform destroy pipeline is triggered manually from the GitHub Actions UI. 
The user must confirm the operation before it proceeds.
Purpose: To clean up and remove resources that are no longer needed in your Azure environment.
Workflow Breakdown
Terraform Plan & Apply (Automated)
Terraform Plan: This job initializes Terraform and generates the execution plan, showing 
what resources will be created, updated, or destroyed.
Example command: terraform plan
Terraform Apply: After the plan is approved, this job applies the changes to the 
infrastructure by running:
Example command: terraform apply -auto-approve
This step automatically applies the changes without requiring further user input.
Terraform Destroy (Manual)
Terraform Destroy: This job is manually triggered, ensuring that a user explicitly confirms 
the intention to destroy the infrastructure. The workflow will not proceed unless the user 
confirms by setting confirm_destroy=true.
Example command: terraform destroy -auto-approve
This operation will destroy all resources managed by Terraform, and it is a destructive 
operation that cannot be undone.