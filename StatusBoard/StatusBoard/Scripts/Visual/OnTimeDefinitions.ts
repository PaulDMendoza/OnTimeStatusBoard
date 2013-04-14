


module OnTime {



    export interface Customer {
        company_name: string;
        company_url: string;

    }


    export interface CustomerContact {
        id: number;
        name: string;
        first_name: string;
        last_name: string;
        email: string;
        phone: string;

    }


    export interface Defect {
        id: number;
        number: string;
        name: string;
        workflow_step: WorkflowStep;
        priority: Priority;
        assigned_to: OnTimeUser;
        project: Project;
        reported_date?: string;
        build_number: string;
        completion_date?: string;
        build_number_of_fix: string;
        severity: Severity;
        status: Status;
        reported_by: OnTimeUser;
        estimated_duration: Duration;
        actual_duration: Duration;
        percent_complete: number;
        publicly_viewable: bool;
        reported_by_customer_contact: CustomerContact;
        created_by: OnTimeUser;
        created_date_time?: string;
        last_updated_by: OnTimeUser;
        last_updated_date_time?: string;
        archived: bool;
        remaining_duration: Duration;
        release: Release;
        vote: Vote;
        is_ranked?: number;
        parent_project: ParentProject;
        customer: Customer;

    }


    export interface Defects {
        data: Defect[];
        metadata: MetaData;

    }


    export interface Duration {
        duration_minutes: number;
        duration_text: string;
        aggregate_duration_minutes: number;

    }


    export interface Feature {
        id: number;
        number: string;
        name: string;
        workflow_step: WorkflowStep;
        priority: Priority;
        project: Project;
        start_date?: string;
        due_date?: string;
        build_number: string;
        completion_date?: string;
        status: Status;
        reported_by: OnTimeUser;
        estimated_duration: Duration;
        actual_duration: Duration;
        percent_complete: number;
        publicly_viewable: bool;
        reported_by_customer_contact: CustomerContact;
        created_by: OnTimeUser;
        created_date_time?: string;
        last_updated_by: OnTimeUser;
        last_updated_date_time?: string;
        archived: bool;
        remaining_duration: Duration;
        release: Release;
        vote: Vote;
        rank?: number;
        is_ranked?: number;
        parent_project: ParentProject;
        customer: Customer;

    }


    export interface Features {
        data: Feature[];
        metadata: MetaData;

    }


    export interface FullOnTimeUser {
        id: number;
        first_name: string;
        last_name: string;
        email: string;
        login_id: string;
        windows_id: string;
        use_windows_auth: string;
        built_in_account: string;
        is_active: bool;
        is_locked: bool;
        enterprise_connection_type: number;
        last_login_date_time?: string;
        has_read_upgrade_message: bool;
        failed_logins: number;
        git_hub_user_id: string;
        created_date_time?: string;

    }


    export interface MetaData {
        total_count: number;
        page?: number;
        page_size: number;

    }


    export interface OnTimeUser {
        id: number;
        name: string;

    }


    export interface ParentProject {
        name: string;

    }


    export interface Priorities {
        data: Priority[];

    }


    export interface Priority {
        id: number;
        order: number;
        name: string;
        color: string;

    }


    export interface Project {
        id: number;
        name: string;
        description: string;
        start_date?: string;
        due_date?: string;
        is_active: bool;
        children: Project[];

    }


    export interface Projects {
        data: Project[];

    }


    export interface Release {
        id: number;
        name: string;
        can_modify: bool;
        start_date?: string;
        due_date?: string;
        velocity_start_date?: string;
        release_notes: string;
        status: number;
        is_active: bool;
        release_type: number;
        children: Release[];

    }


    export interface Releases {
        data: Release[];

    }


    export interface Severities {
        data: Severity[];

    }


    export interface Severity {
        id: number;
        order: number;
        name: string;
        color: string;

    }


    export interface Status {
        id: number;
        order: number;
        name: string;

    }


    export interface Users {
        data: FullOnTimeUser[];

    }


    export interface Vote {
        count: number;
        average: number;

    }


    export interface WorkflowStep {
        id: number;
        order: number;
        name: string;

    }



}

